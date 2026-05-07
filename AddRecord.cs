using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TravelPass
{
    public partial class AddRecord : Form
    {
        private Control _threadHelperControl;
        bool btnSV_doe = false;
        bool btnSV_checks = false;
        bool btnSV_valid = false;
        Hashtable hashtable = new Hashtable();

        // Post-dated visa detection state (reset on each Clear).
        bool isPostDated = false;
        DateTime visaStartDate = DateTime.MinValue;
        

        string signed_attrs = "NO READ DATA";
        string passive_auth = "NO READ DATA";
        string chip_auth = "NO READ DATA";
        string sign_ = "NO READ DATA";
        string active_auth = "NO READ DATA";
        string term_auth = "NO READ DATA";
        string doc_signer_cert = "NO READ DATA";

        string storedRecordName = "";
        string aCodelineData;
        string record_folder_name = "";
        bool hasStoredRecoredName = false;

        bool sa_ = true;
        bool pa_ = true;
        bool ca_ = true;
        bool si_ = true;
        bool aa_ = true;
        bool ta_ = true;
        bool docsc_ = true;

        DateTime myDOB; //iC<>deiDesign

        public AddRecord()
        {
            InitializeComponent();
            mrzScan1.BringToFront();
            this.timer2.Interval = 500;
            this.timer2.Enabled = false;

            this.timer3.Interval = 500;
            this.timer3.Enabled = false;


            this.timer1.Tick += new System.EventHandler(this.InitialiseTimer);
            this.timer2.Tick += new System.EventHandler(this.InitialiseTimer2);
            this.timer3.Tick += new System.EventHandler(this.InitialiseTimer3);

            _threadHelperControl = new Control();
            _threadHelperControl.CreateControl();
        }
        


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        void DataCallbackThreadHelper(MMM.Readers.FullPage.DataType aDataType, object aData)
        {
            if (_threadHelperControl.InvokeRequired)
            {
                _threadHelperControl.Invoke(
                    new MMM.Readers.FullPage.DataDelegate(DataCallback),
                    new object[] { aDataType, aData }
                );
            }
            else
            {
                DataCallback(aDataType, aData);
            }
        }

        void HighlightCodelineCheckDigits(MMM.Readers.CodelineData aCodeline)
        {
            for (int loop = 0; loop < aCodeline.CheckDigitDataListCount; loop++)
            {
                MMM.Readers.CodelineCheckDigitData lCDData = aCodeline.CheckDigitDataList[loop];
                int lIndex = lCDData.puCodelinePos;
                for (int line = 1; line < lCDData.puCodelineNumber; line++)
                {
                    switch (line)
                    {
                        case 1:
                            lIndex += aCodeline.Line1.Length;
                            ++lIndex; //Add 1 for EOL char
                            break;
                        case 2:
                            lIndex += aCodeline.Line2.Length;
                            ++lIndex; //Add 1 for EOL char
                            break;
                    }
                }


                mrzScan1.richTextBoxCodeline.Select(lIndex, 1);
                if (lCDData.puValueExpected == lCDData.puValueRead)
                    mrzScan1.richTextBoxCodeline.SelectionColor = Color.Green;
                else
                    mrzScan1.richTextBoxCodeline.SelectionColor = Color.Red;
                mrzScan1.richTextBoxCodeline.DeselectAll();
            }
        }



        void _HighlightCodelineCheckDigits(MMM.Readers.CodelineData aCodeline)
        {
            for (int loop = 0; loop < aCodeline.CheckDigitDataListCount; loop++)
            {
                MMM.Readers.CodelineCheckDigitData lCDData = aCodeline.CheckDigitDataList[loop];

                int lIndex = lCDData.puCodelinePos;
                for (int line = 1; line < lCDData.puCodelineNumber; line++)
                {
                    switch (line)
                    {
                        case 1:
                            lIndex += aCodeline.Line1.Length;
                            ++lIndex; //Add 1 for EOL char
                            break;
                        case 2:
                            lIndex += aCodeline.Line2.Length;
                            ++lIndex; //Add 1 for EOL char
                            break;
                    }
                }


                rfidScan1.codelineRichTextBox.Select(lIndex, 1);
                if (lCDData.puValueExpected == lCDData.puValueRead)
                    rfidScan1.codelineRichTextBox.SelectionColor = Color.Green;
                else
                    rfidScan1.codelineRichTextBox.SelectionColor = Color.Red;
                rfidScan1.codelineRichTextBox.DeselectAll();
            }
        }

        public static int[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (int[])converter.ConvertTo(img, typeof(int[]));
        }

        void DataCallback(MMM.Readers.FullPage.DataType aDataType, object aData)
        {
            try
            {
                LogDataItem(aDataType, aData);

                if (aData != null)
                {
                    switch (aDataType)
                    {
                        case MMM.Readers.FullPage.DataType.CD_CODELINE_DATA:
                            {

                                MMM.Readers.CodelineData codeline = (MMM.Readers.CodelineData)aData;
                                mrzScan1.richTextBoxCodeline.Text =
                                    codeline.Line1 + "\n" +
                                    codeline.Line2 + "\n" +
                                    codeline.Line3;
                                HighlightCodelineCheckDigits(codeline);
                                aCodelineData = codeline.ToString();
                                mrzScan1.opt_data.Text = codeline.OptionalData1.ToString();
                                if (codeline.CodelineValidationResult.ToString().Trim().Equals("CDR_Valid"))
                                {
                                    mrzScan1.oid_flag.Text = "OK";
                                    mrzScan1.oid_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                }
                                else
                                {
                                    mrzScan1.oid_flag.Text = "ERROR";
                                    mrzScan1.oid_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                                mrzScan1.family_name.Text = codeline.Surname;
                                mrzScan1.given_names.Text = codeline.Forenames;
                                mrzScan1.sex.Text = codeline.Sex;
                                mrzScan1.dob.Text = string.Format(
                                    "{0:00}-{1:00}-{2:00}",
                                    codeline.DateOfBirth.Day,
                                    codeline.DateOfBirth.Month,
                                    codeline.DateOfBirth.Year
                                );
                                //DateTime temp;
                                try {
                                    if (/**DateTime.TryParse(mrzScan1.dob.Text, out temp)**/ !mrzScan1.dob.Text.Contains("*") || !(mrzScan1.dob.Text.Length < 1))
                                    {
                                        DateTime age_now = new DateTime();
                                        age_now = DateTime.Now;
                                        int age = age_now.Year - System.Globalization.CultureInfo.CurrentCulture.Calendar.ToFourDigitYear(codeline.DateOfBirth.Year);
                                        //mrzScan1.age.Text = age.ToString();
                                        mrzScan1.dob_flag.Text = "OK";
                                        mrzScan1.dob_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                    }
                                    else
                                    {
                                        mrzScan1.dob_flag.Text = "ERROR";
                                        mrzScan1.dob_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                    }
                                }
                                catch (Exception ex) {
                                    File.WriteAllText("C:/TravelPass Files/log files/ERR-" + DateTime.Now.ToString("HH:mm:ss:f").Replace(":", "#") + ".txt", ex.Message.ToString());

                                }

                                mrzScan1.doc_no.Text = codeline.DocNumber;
                                if (mrzScan1.doc_no.TextLength > 1 && !mrzScan1.doc_no.Text.Contains("*"))
                                {
                                    mrzScan1.doc_no_flag.Text = "OK";
                                    mrzScan1.doc_no_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                }
                                else
                                {
                                    mrzScan1.doc_no_flag.Text = "ERROR";
                                    mrzScan1.doc_no_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                                try {
                                    doc_type.Text = codeline.DocType.ToUpper().ToString().Substring(0, 11);
                                }
                                catch (Exception ex) {
                                    doc_type.Text = codeline.DocType.ToUpper().ToString();
                                    Console.WriteLine(ex.ToString());
                                }


                                mrzScan1.issuer.Text = codeline.IssuingState;
                                mrzScan1.nationality.Text = codeline.Nationality;
                                mrzScan1.doe.Text = string.Format(
                                    "{0:00}-{1:00}-{2:00}",
                                    codeline.ExpiryDate.Day,
                                    codeline.ExpiryDate.Month,
                                    codeline.ExpiryDate.Year 
                                );
                                if (codeline.CodelineValidationResult.ToString().Trim().Equals("CDR_Valid"))
                                {
                                    btnSV_valid = true;
                                    mrzScan1.vd_flag.Text = "OK";
                                    mrzScan1.vd_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                }
                                else
                                {
                                    btnSV_valid = false;
                                    mrzScan1.vd_flag.Text = "ERROR";
                                    mrzScan1.vd_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                                //DateTime temp1;
                                if (/**DateTime.TryParse(mrzScan1.doe.Text, out temp1)**/!mrzScan1.doe.Text.Contains("*") || !(mrzScan1.doe.Text.Length < 1))
                                {
                                    //File.WriteAllText("C:/TravelPass Files/log files/ERR-" + DateTime.Now.ToString("HH:mm:ss:f").Replace(":", "#") + ".txt", "Converted " + mrzScan1.doe.Text + " to " + temp1 + " " + temp1.Kind);
                                    try
                                    {
                                        if (codeline.ExpiredDocumentFlag)
                                        {
                                            DateTime now = new DateTime();
                                            now = DateTime.Now;
                                            int yr = now.Year - System.Globalization.CultureInfo.CurrentCulture.Calendar.ToFourDigitYear(codeline.ExpiryDate.Year);
                                            if (yr < 0)
                                            {
                                                yr = 0;
                                            }
                                            if (yr == 0)
                                            {
                                                mrzScan1.expired_txt.Text = "Document Expired since " + Math.Abs(now.Month - codeline.ExpiryDate.Month) + " Months " + Math.Abs(now.Day - codeline.ExpiryDate.Day) + " Days";
                                            }
                                            else
                                            {
                                                mrzScan1.expired_txt.Text = "Document Expired since " + yr + " Years " + Math.Abs(now.Month - codeline.ExpiryDate.Month) + " Months " + Math.Abs(now.Day - codeline.ExpiryDate.Day) + " Days";
                                            }
                                            mrzScan1.expired_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));

                                            btnSV_doe = false;
                                            mrzScan1.doe_flag.Text = "ERROR";
                                            mrzScan1.doe_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                        }
                                        else
                                        {
                                            //iC<>deiDesign //I was the one that commented the code below, since I have written a more reliable logic in the "EventCallback" event
                                            //DateTime now = new DateTime();
                                            //DateTime dt = new DateTime();
                                            //dt = DateTime.Parse(mrzScan1.doe.Text);
                                            //now = DateTime.Now;
                                            //int yr = dt.Year - now.Year;
                                            //if (yr <= 1)
                                            //{
                                            //    yr = 0;
                                            //}
                                            //if (yr == 0)
                                            //{
                                            //    mrzScan1.expired_txt.Text = "Document Expires in " + dt.Month + " Months " + Math.Abs(now.Day - dt.Day) + " Days";
                                            //}
                                            //else
                                            //{
                                            //    mrzScan1.expired_txt.Text = "Document Expires in " + yr + " Years " + Math.Abs(now.Month - dt.Month) + " Months " + Math.Abs(now.Day - dt.Day) + " Days";
                                            //}
                                            mrzScan1.expired_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));

                                            btnSV_doe = true;
                                            mrzScan1.doe_flag.Text = "OK";
                                            mrzScan1.doe_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                        }
                                    }
                                    catch (Exception ex) {
                                        File.WriteAllText("C:/TravelPass Files/log files/ERR-" + DateTime.Now.ToString("HH:mm:ss:f").Replace(":", "#") + ".txt", ex.Message.ToString());

                                    }

                                }
                                else {
                                    File.WriteAllText("C:/TravelPass Files/log files/ERR-" + DateTime.Now.ToString("HH:mm:ss:f").Replace(":", "#") + ".txt", "Unable to parse " + mrzScan1.doe.Text);
                                    btnSV_doe = false;
                                    mrzScan1.doe_flag.Text = "ERROR";
                                    mrzScan1.doe_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }

                                foreach(_FlaggedDocOwner _do in _Public.flagged_doc_owners)
                                {

                                    if (_do.document_owner.family_name.ToLower().Equals(mrzScan1.family_name.Text.Trim().ToLower()) && _do.document_owner.given_names.ToLower().Equals(mrzScan1.given_names.Text.Trim().ToLower()) && (mrzScan1.family_name.Text.Length > 0 && mrzScan1.given_names.Text.Length > 0))
                                    {
                                        mrzScan1.flagged_flag.Text = "YES";
                                        mrzScan1.flagged_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                        break;
                                    }
                                    else
                                    {
                                        mrzScan1.flagged_flag.Text = "NO";
                                        mrzScan1.flagged_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                    }
                                }

                                // Post-dated visa detection: attempt to extract a validity
                                // start date from the MRZ optional data field and flag the
                                // document if the start date lies in the future.
                                if (PostDatedVisaDetector.IsVisaDocType(this.doc_type.Text))
                                {
                                    DateTime detectedStart;
                                    if (PostDatedVisaDetector.TryExtractStartDate(
                                            mrzScan1.opt_data.Text, out detectedStart))
                                    {
                                        visaStartDate = detectedStart;
                                        isPostDated   = PostDatedVisaDetector.IsPostDated(detectedStart);
                                        string statusText = PostDatedVisaDetector.GetStatusText(detectedStart);

                                        if (isPostDated)
                                        {
                                            mrzScan1.expired_txt.Text      = statusText;
                                            mrzScan1.expired_txt.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
                                        }
                                        else if (detectedStart != DateTime.MinValue)
                                        {
                                            mrzScan1.expired_txt.Text      = statusText;
                                            mrzScan1.expired_txt.ForeColor = System.Drawing.Color.FromArgb(0, 140, 0);
                                        }
                                    }
                                }

                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_IMAGEIR:
                            {
                                viewImages1.irImage.Image = aData as Bitmap;
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_IMAGEVIS:
                            {
                                viewImages1.visImage.Image = aData as Bitmap;
                                //MMM.Readers.FullPage.ValidateDocPositionDelegate @d = new MMM.Readers.FullPage.ValidateDocPositionDelegate(_do);
                                //d.BeginInvoke
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_IMAGEPHOTO:
                            {
                                mrzScan1.mrzImage.Image = aData as Bitmap;
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_IMAGEUV:
                            {
                                int a = 0;
                                viewImages1.uvImage.Image = aData as Bitmap;
                                //Bitmap bmp = new Bitmap(viewImages1.uvImage.Image);
                                //// Retrieve the bitmap data from the bitmap.
                                //System.Drawing.Imaging.BitmapData bmpData = new System.Drawing.Imaging.BitmapData();
                                //bmpData.Scan0 = 

                                ////Create a new bitmap.
                                //Bitmap newBitmap = new Bitmap(200, 200, bmpData.Stride, bmp.PixelFormat, bmpData.Scan0);

                                //bmp.UnlockBits(bmpData);


                                //MMM.Readers.Modules.Imaging.PerformSecurityCheck(new IntPtr((void*)pArray), aCodelineData, ref a);

                                //Console.WriteLine("aaaaaaaaaaaa ======== + " + a);
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_CHECKSUM:
                            {
                                Console.WriteLine("CheckSum = " + aData as String);
                                if (Convert.ToInt32(aData) > 0)
                                {
                                    btnSV_checks = true;
                                    mrzScan1.checks_flag.Text = "OK";
                                    mrzScan1.checks_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));

                                }
                                else if (Convert.ToInt32(aData) == -1)
                                {
                                    btnSV_checks = false;
                                    mrzScan1.checks_flag.Text = "ERROR";
                                    mrzScan1.checks_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                }
                                else if (Convert.ToInt32(aData) < -1)
                                {
                                    btnSV_checks = true;
                                    mrzScan1.checks_flag.Text = "WARN";
                                    mrzScan1.checks_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                }
                                else if (Convert.ToInt32(aData) == 0)
                                {
                                    btnSV_checks = false;
                                    mrzScan1.checks_flag.Text = "NONE";
                                    mrzScan1.checks_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
                                }
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_VERIFIER_RESULT:
                            {
                                Console.WriteLine("Verifier Result = " + aData as String);
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SECURITYCHECK:
                            {
                                Console.WriteLine("Security Check type = " + aData);
                                if (Convert.ToInt32(aData) == 0)
                                {
                                    viewImages1.irVerify.Text = "FAILED";
                                    viewImages1.irVerify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                                    viewImages1.uvVerify.Text = "FAILED";
                                    viewImages1.uvVerify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));

                                }
                                else if (Convert.ToInt32(aData) == 1)
                                {
                                    viewImages1.irVerify.Text = "PASSED";
                                    viewImages1.irVerify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                    viewImages1.uvVerify.Text = "FAILED";
                                    viewImages1.uvVerify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));

                                }
                                else {
                                    viewImages1.irVerify.Text = "PASSED";
                                    viewImages1.irVerify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                                    viewImages1.uvVerify.Text = "PASSED";
                                    viewImages1.uvVerify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));

                                }
                                break;
                            }

                        //  ************MUST REVISIT THIS*****************//
                        case MMM.Readers.FullPage.DataType.CD_BACKEY_CORRECTION:
                            {
                                bool lTemp = _threadHelperControl.InvokeRequired;
                                {
                                    System.Text.StringBuilder lStringBuilder =
                                        aData as System.Text.StringBuilder;

                                    if (lStringBuilder != null)
                                    {
                                        FormBACKeyCorrection lForm = new FormBACKeyCorrection();
                                        lForm.SetCodeline(lStringBuilder.ToString());

                                        //Just commented this out on 21/05/25
                                        //if (lForm.ShowDialog() == DialogResult.OK)
                                        //{
                                        //    lStringBuilder.Replace(
                                        //        lStringBuilder.ToString(),
                                        //        lForm.GetCodeline()
                                        //    );
                                        //}
                                    }
                                }
                                break;
                            }

                        //*****Not doing CODELINE READ FOR RFID * ***
                        case MMM.Readers.FullPage.DataType.CD_SCDG1_CODELINE_DATA:
                            {
                                MMM.Readers.CodelineData codeline = (MMM.Readers.CodelineData)aData;

                                rfidScan1.codelineRichTextBox.Text =
                                    codeline.Line1 + "\n" +
                                    codeline.Line2 + "\n" +
                                    codeline.Line3;

                                _HighlightCodelineCheckDigits(codeline);

                                //lblRFSurname.Text = codeline.Surname;
                                //lblRFForenames.Text = codeline.Forenames;
                                //lblRFNationality.Text = codeline.Nationality;
                                //lblRFSex.Text = codeline.Sex;
                                //lblRFDateOfBirth.Text = string.Format(
                                //    "{0:00}-{1:00}-{2:00}",
                                //    codeline.DateOfBirth.Day,
                                //    codeline.DateOfBirth.Month,
                                //    codeline.DateOfBirth.Year
                                //);
                                //lblRFDocNumber.Text = codeline.DocNumber;
                                break;
                            }

                        case MMM.Readers.FullPage.DataType.CD_SCDG2_PHOTO:
                        case MMM.Readers.FullPage.DataType.CD_SCDG6_EDL_PHOTO:
                            {
                                byte[] lInputBuffer = aData as byte[];
                                try
                                {
                                    // .NET bitmaps can be constructed from JPEG images
                                    System.IO.Stream streamBuffer = new System.IO.MemoryStream();
                                    streamBuffer.Write(lInputBuffer, 0, lInputBuffer.Length);
                                    streamBuffer.Seek(0, System.IO.SeekOrigin.Begin);
                                    rfidScan1.rfImage.Image = new Bitmap(streamBuffer);
                                }
                                catch (Exception imgExcept)
                                {
                                    // but it throws an exception if its a JPEG 2000. You can use the 
                                    // low level API to convert JPEG 2000 to BMP though.
                                    byte[] lOutputBuffer = null;

                                    MMM.Readers.Modules.Imaging.ConvertFormat
                                                (MMM.Readers.FullPage.ImageFormats.RTE_BMP,
                                                lInputBuffer, out lOutputBuffer);

                                    if (lOutputBuffer != null)
                                    {
                                        try
                                        {
                                            System.IO.Stream j2kStream = new System.IO.MemoryStream();
                                            j2kStream.Write(lOutputBuffer, 0, lOutputBuffer.Length);
                                            j2kStream.Seek(0, System.IO.SeekOrigin.Begin);
                                            rfidScan1.rfImage.Image = new Bitmap(j2kStream);
                                        }
                                        catch (Exception decodeExcept)
                                        {
                                            System.Windows.Forms.MessageBox.Show(decodeExcept.ToString());
                                        }
                                    }
                                }

                                break;
                            }

                        case MMM.Readers.FullPage.DataType.CD_SCCHIPID:
                            {
                                rfidScan1.chipID.Text = "CHIP ID - " + aData as String;
                                break;
                            }

                        case MMM.Readers.FullPage.DataType.CD_SCDG1_VALIDATE:
                            {
                                rfidScan1.dg_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG2_VALIDATE:
                            {
                                rfidScan1.dg_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG3_VALIDATE:
                            {
                                rfidScan1.dg_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG4_VALIDATE:
                            {
                                rfidScan1.dg_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG5_VALIDATE:
                            {
                                rfidScan1.dg_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG6_VALIDATE:
                            {
                                rfidScan1.dg_6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG7_VALIDATE:
                            {
                                rfidScan1.dg_7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG8_VALIDATE:
                            {
                                rfidScan1.dg_8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG9_VALIDATE:
                            {
                                rfidScan1.dg_9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG10_VALIDATE:
                            {
                                rfidScan1.dg_10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG11_VALIDATE:
                            {
                                rfidScan1.dg_11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG12_VALIDATE:
                            {
                                rfidScan1.dg_12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG13_VALIDATE:
                            {
                                rfidScan1.dg_13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG14_VALIDATE:
                            {
                                rfidScan1.dg_14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG15_VALIDATE:
                            {
                                rfidScan1.dg_15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG16_VALIDATE:
                            {
                                rfidScan1.dg_16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG1_VALIDATE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG2_VALIDATE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG3_VALIDATE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG4_VALIDATE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG5_VALIDATE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG6_VALIDATE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG7_VALIDATE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG8_VALIDATE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG9_VALIDATE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG10_VALIDATE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG11_VALIDATE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG12_VALIDATE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG13_VALIDATE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG14_VALIDATE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG15_VALIDATE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG16_VALIDATE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG17_VALIDATE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG18_VALIDATE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG19_VALIDATE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG20_VALIDATE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG21_VALIDATE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG22_VALIDATE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG1_VALIDATE_EDL:
                        case MMM.Readers.FullPage.DataType.CD_SCDG2_VALIDATE_EDL:
                        case MMM.Readers.FullPage.DataType.CD_SCDG3_VALIDATE_EDL:
                        case MMM.Readers.FullPage.DataType.CD_SCDG4_VALIDATE_EDL:
                        case MMM.Readers.FullPage.DataType.CD_SCDG5_VALIDATE_EDL:
                        case MMM.Readers.FullPage.DataType.CD_SCDG6_VALIDATE_EDL:
                        case MMM.Readers.FullPage.DataType.CD_SCDG7_VALIDATE_EDL:
                        case MMM.Readers.FullPage.DataType.CD_SCDG8_VALIDATE_EDL:
                        case MMM.Readers.FullPage.DataType.CD_SCDG9_VALIDATE_EDL:
                        case MMM.Readers.FullPage.DataType.CD_SCDG10_VALIDATE_EDL:
                        case MMM.Readers.FullPage.DataType.CD_SCDG11_VALIDATE_EDL:
                        case MMM.Readers.FullPage.DataType.CD_SCDG12_VALIDATE_EDL:
                        case MMM.Readers.FullPage.DataType.CD_SCDG13_VALIDATE_EDL:
                        case MMM.Readers.FullPage.DataType.CD_SCDG14_VALIDATE_EDL:

                        case MMM.Readers.FullPage.DataType.CD_SCSIGNEDATTRS_VALIDATE:
                            {
                                MMM.Readers.Modules.RF.ValidationCode lValidationResult = (MMM.Readers.Modules.RF.ValidationCode)aData;
                                if (lValidationResult.ToString().Equals("RFID_VC_VALID"))
                                {
                                    signed_attrs = "RFID_VC_VALID";
                                    rfidScan1.saImage.Image = global::TravelPass.Properties.Resources.if_check_1930264;
                                    sa_ = true;
                                }
                                else
                                {
                                    signed_attrs = "RFID_VC_INVALID";
                                    rfidScan1.saImage.Image = global::TravelPass.Properties.Resources.if_Close_1891023;
                                    sa_ = false;
                                }
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCSIGNEDATTRS_VALIDATE_CARD_SECURITY_FILE:
                        case MMM.Readers.FullPage.DataType.CD_SCSIGNEDATTRS_VALIDATE_CHIP_SECURITY_FILE:
                        case MMM.Readers.FullPage.DataType.CD_SCSIGNATURE_VALIDATE:
                            {
                                MMM.Readers.Modules.RF.ValidationCode lValidationResult = (MMM.Readers.Modules.RF.ValidationCode)aData;
                                if (lValidationResult.ToString().Equals("RFID_VC_VALID"))
                                {
                                    sign_ = "RFID_VC_VALID";
                                    rfidScan1.siImage.Image = global::TravelPass.Properties.Resources.if_check_1930264;
                                    si_ = true;
                                }
                                else {
                                    sign_ = "RFID_VC_INVALID";
                                    rfidScan1.siImage.Image = global::TravelPass.Properties.Resources.if_Close_1891023;
                                    si_ = false;
                                }
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCSIGNATURE_VALIDATE_CARD_SECURITY_FILE:
                        case MMM.Readers.FullPage.DataType.CD_SCSIGNATURE_VALIDATE_CHIP_SECURITY_FILE:
                        case MMM.Readers.FullPage.DataType.CD_VALIDATE_DOC_SIGNER_CERT:
                            {
                                MMM.Readers.Modules.RF.ValidationCode lValidationResult = (MMM.Readers.Modules.RF.ValidationCode)aData;
                                if (lValidationResult.ToString().Equals("RFID_VC_VALID"))
                                {
                                    doc_signer_cert = "RFID_VC_VALID";
                                    rfidScan1.docsImage.Image = global::TravelPass.Properties.Resources.if_check_1930264;
                                    docsc_ = true;
                                }
                                else if (lValidationResult.ToString().Equals("RFID_VC_INVALID"))
                                {
                                    doc_signer_cert = "RFID_VC_INVALID";
                                    rfidScan1.docsImage.Image = global::TravelPass.Properties.Resources.if_Close_1891023;
                                    docsc_ = false;
                                }
                                else if (lValidationResult.ToString().Equals("RFID_VC_NO_CSC_LOADED"))
                                {
                                    doc_signer_cert = "RFID_VC_NO_CSC_LOADING";
                                    rfidScan1.docsImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
                                    docsc_ = true;
                                }
                                else if (lValidationResult.ToString().Equals("RFID_VC_NO_DSC_LOADED"))
                                {
                                    doc_signer_cert = "RFID_VC_NO_DSC_LOADING";
                                    rfidScan1.docsImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
                                    docsc_ = true;
                                }
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_PASSIVE_AUTHENTICATION:
                            {
                                MMM.Readers.Modules.RF.TriState lState = (MMM.Readers.Modules.RF.TriState)aData;
                                if (lState.ToString().Equals("TS_SUCCESS"))
                                {
                                    passive_auth = "TS_SUCCESS";
                                    rfidScan1.paImage.Image = global::TravelPass.Properties.Resources.if_check_1930264;
                                    pa_ = true;
                                }
                                else if (lState.ToString().Equals("TS_FAILURE"))
                                {
                                    passive_auth = "TS_FAILURE";
                                    rfidScan1.paImage.Image = global::TravelPass.Properties.Resources.if_Close_1891023;
                                    pa_ = false;
                                }
                                else
                                {
                                    passive_auth = "TS_NOT_PERFORMED";
                                    rfidScan1.paImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
                                    pa_ = true;
                                }
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_ACTIVE_AUTHENTICATION:
                            {
                                MMM.Readers.Modules.RF.TriState lState = (MMM.Readers.Modules.RF.TriState)aData;
                                if (lState.ToString().Equals("TS_SUCCESS"))
                                {
                                    active_auth = "TS_SUCCESS";
                                    rfidScan1.aaImage.Image = global::TravelPass.Properties.Resources.if_check_1930264;
                                    aa_ = true;
                                }
                                else if (lState.ToString().Equals("TS_FAILURE"))
                                {
                                    active_auth = "TS_FAILURE";
                                    rfidScan1.aaImage.Image = global::TravelPass.Properties.Resources.if_Close_1891023;
                                    aa_ = false;
                                }
                                else {
                                    active_auth = "TS_NOT_PERFORMED";
                                    rfidScan1.aaImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
                                    aa_ = true;
                                }
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCBAC_STATUS:
                        case MMM.Readers.FullPage.DataType.CD_SAC_STATUS:
                        case MMM.Readers.FullPage.DataType.CD_SCTERMINAL_AUTHENTICATION_STATUS:
                            {
                                MMM.Readers.Modules.RF.TriState lState = (MMM.Readers.Modules.RF.TriState)aData;
                                if (lState.ToString().Equals("TS_SUCCESS"))
                                {
                                    term_auth = "TS_SUCCESS";
                                    rfidScan1.taImage.Image = global::TravelPass.Properties.Resources.if_check_1930264;
                                    ta_ = true;
                                }
                                else if (lState.ToString().Equals("TS_FAILURE"))
                                {
                                    term_auth = "TS_FAILURE";
                                    rfidScan1.taImage.Image = global::TravelPass.Properties.Resources.if_Close_1891023;
                                    ta_ = false;
                                }
                                else
                                {
                                    term_auth = "TS_NOT_PERFORMED";
                                    rfidScan1.taImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
                                    ta_ = true;
                                }
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCCHIP_AUTHENTICATION_STATUS:
                            {
                                MMM.Readers.Modules.RF.TriState lState = (MMM.Readers.Modules.RF.TriState)aData;
                                Console.WriteLine(aDataType.ToString() + "***********" + lState.ToString());
                                if (lState.ToString().Equals("TS_SUCCESS"))
                                {
                                    chip_auth = "TS_SUCCESS";
                                    rfidScan1.caImage.Image = global::TravelPass.Properties.Resources.if_check_1930264;
                                    ca_ = true;
                                }
                                else if (lState.ToString().Equals("TS_FAILURE"))
                                {
                                    chip_auth = "TS_FAILURE";
                                    rfidScan1.caImage.Image = global::TravelPass.Properties.Resources.if_Close_1891023;
                                    ca_ = false;
                                }
                                else
                                {
                                    chip_auth = "TS_NOT_PERFORMED";
                                    rfidScan1.caImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
                                    ca_ = true;
                                }
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG1_FILE: {
                                rfidScan1.dg1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG2_FILE: {
                                rfidScan1.dg2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG3_FILE:
                            {
                                rfidScan1.dg3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG4_FILE:
                            {
                                rfidScan1.dg4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG5_FILE:
                            {
                                rfidScan1.dg5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG6_FILE:
                            {
                                rfidScan1.dg6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG7_FILE:
                            {
                                rfidScan1.dg7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG8_FILE:
                            {
                                rfidScan1.dg8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG9_FILE:
                            {
                                rfidScan1.dg9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG10_FILE:
                            {
                                rfidScan1.dg10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG11_FILE:
                            {
                                rfidScan1.dg11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG12_FILE:
                            {
                                rfidScan1.dg12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG13_FILE:
                            {
                                rfidScan1.dg13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG14_FILE:
                            {
                                rfidScan1.dg14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG15_FILE:
                            {
                                rfidScan1.dg15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG16_FILE:
                            {
                                rfidScan1.dg16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG1_FILE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG2_FILE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG3_FILE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG4_FILE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG5_FILE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG6_FILE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG7_FILE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG8_FILE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG9_FILE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG10_FILE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG11_FILE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG12_FILE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG13_FILE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG14_FILE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG15_FILE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG16_FILE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG17_FILE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG18_FILE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG19_FILE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG20_FILE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG21_FILE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG22_FILE_EID:
                        case MMM.Readers.FullPage.DataType.CD_SCEF_COM_FILE: {
                                Console.WriteLine("victor is here");
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCEF_SOD_FILE:
                        case MMM.Readers.FullPage.DataType.CD_SCEF_CVCA_FILE:
                        case MMM.Readers.FullPage.DataType.CD_SCEF_CARD_SECURITY_FILE:
                        case MMM.Readers.FullPage.DataType.CD_SCEF_CHIP_SECURITY_FILE:
                        case MMM.Readers.FullPage.DataType.CD_SCDG1_FILE_EDL:
                        case MMM.Readers.FullPage.DataType.CD_SCDG2_FILE_EDL:
                        case MMM.Readers.FullPage.DataType.CD_SCDG3_FILE_EDL:
                        case MMM.Readers.FullPage.DataType.CD_SCDG4_FILE_EDL:
                        case MMM.Readers.FullPage.DataType.CD_SCDG5_FILE_EDL:
                        case MMM.Readers.FullPage.DataType.CD_SCDG6_FILE_EDL:
                        case MMM.Readers.FullPage.DataType.CD_SCDG7_FILE_EDL:
                        case MMM.Readers.FullPage.DataType.CD_SCDG8_FILE_EDL:
                        case MMM.Readers.FullPage.DataType.CD_SCDG9_FILE_EDL:
                        case MMM.Readers.FullPage.DataType.CD_SCDG10_FILE_EDL:
                        case MMM.Readers.FullPage.DataType.CD_SCDG11_FILE_EDL:
                        case MMM.Readers.FullPage.DataType.CD_SCDG12_FILE_EDL:
                        case MMM.Readers.FullPage.DataType.CD_SCDG13_FILE_EDL:
                        case MMM.Readers.FullPage.DataType.CD_SCDG14_FILE_EDL:
                            {
                                byte[] lFileData = aData as byte[];
                                Console.WriteLine(aDataType.ToString() + "***********" + lFileData.Length.ToString() + " bytes");
                                break;
                            }

                        //case MMM.Readers.FullPage.DataType.CD_UHF_EPC:
                        //    {
                        //        String lEPCString = "";
                        //        foreach (byte lByte in (byte[])aData)
                        //        {
                        //            if (lEPCString.Length != 0)
                        //                lEPCString += "-";
                        //            lEPCString += lByte.ToString("X4");
                        //        }

                        //        EPCField.Text = lEPCString;
                        //        break;
                        //    }
                        //case MMM.Readers.FullPage.DataType.CD_UHF_TAGID:
                        //    {
                        //        if (aData is MMM.Readers.FullPage.UHFTagIDData)
                        //        {
                        //            DisplayUHFTagID(
                        //                (MMM.Readers.FullPage.UHFTagIDData)aData);
                        //        }
                        //        break;
                        //    }
                        #region eID
                        // eID related data for reference
                        case MMM.Readers.FullPage.DataType.CD_SCDG2_EID_ISSUING_ENTITY:
                            {
                                MMM.Readers.FullPage.EIDASIssuingEntity data = (MMM.Readers.FullPage.EIDASIssuingEntity)aData;
                                int x = 0;
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG3_EID_VALIDITY_PERIOD:
                            {
                                MMM.Readers.FullPage.EIDASValidityPeriod data = (MMM.Readers.FullPage.EIDASValidityPeriod)aData;
                                int x = 0;
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG9_EID_PLACE_OF_BIRTH:
                            {
                                MMM.Readers.FullPage.EIDASGeneralPlace data = (MMM.Readers.FullPage.EIDASGeneralPlace)aData;
                                int x = 0;
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG17_EID_PLACE_OF_RESIDENCE:
                            {
                                MMM.Readers.FullPage.EIDASPlaceOfResidence data = (MMM.Readers.FullPage.EIDASPlaceOfResidence)aData;
                                int x = 0;
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG12_EID_OPTIONAL_DATA_R:
                        case MMM.Readers.FullPage.DataType.CD_SCDG14_EID_WRITTEN_SIGNATURE:
                        case MMM.Readers.FullPage.DataType.CD_SCDG18_EID_MUNICIPALITY_ID:
                        case MMM.Readers.FullPage.DataType.CD_SCDG21_EID_OPTIONAL_DATA_RW:
                            {
                                byte[] data = (byte[])aData;
                                int x = 0;
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCDG1_EID_DOCUMENT_TYPE:
                        case MMM.Readers.FullPage.DataType.CD_SCDG4_EID_GIVEN_NAMES:
                        case MMM.Readers.FullPage.DataType.CD_SCDG5_EID_FAMILY_NAMES:
                        case MMM.Readers.FullPage.DataType.CD_SCDG6_EID_NOM_DE_PLUME:
                        case MMM.Readers.FullPage.DataType.CD_SCDG7_EID_ACADEMIC_TITLE:
                        case MMM.Readers.FullPage.DataType.CD_SCDG8_EID_DATE_OF_BIRTH:
                        case MMM.Readers.FullPage.DataType.CD_SCDG10_EID_NATIONALITY:
                        case MMM.Readers.FullPage.DataType.CD_SCDG11_EID_SEX:
                        case MMM.Readers.FullPage.DataType.CD_SCDG13_EID_BIRTH_NAME:
                        case MMM.Readers.FullPage.DataType.CD_SCDG19_EID_RESIDENCE_PERMIT_1:
                        case MMM.Readers.FullPage.DataType.CD_SCDG20_EID_RESIDENCE_PERMIT_2:
                            {
                                string test = aData.ToString();
                                Console.WriteLine("TEST DATA FROM RFID " + test);
                                break;
                            }
                        #endregion
                        case MMM.Readers.FullPage.DataType.CD_SCDG1_EDL_DATA:
                            {
                                MMM.Readers.FullPage.EDLDataGroup1Data data = (MMM.Readers.FullPage.EDLDataGroup1Data)aData;
                                break;
                            }
                    }

                    switch (aDataType)
                    {
                        case MMM.Readers.FullPage.DataType.CD_SCBAC_STATUS:
                            {
                                MMM.Readers.Modules.RF.TriState lState = (MMM.Readers.Modules.RF.TriState)aData;
                                Console.WriteLine(lState.ToString());
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SAC_STATUS:
                            {
                                MMM.Readers.Modules.RF.TriState lState = (MMM.Readers.Modules.RF.TriState)aData;
                                Console.WriteLine(lState.ToString());
                                break;
                            }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    e.ToString(),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            #region //iC<>deiDesign Fixing the reported DOB issue here 'cause I dont want to touch the former code
            if (mrzScan1.dob.Text != String.Empty && mrzScan1.dob.Text != "-01--01--01" )
            {
                try
                {
                    myDOB = DateTime.ParseExact(mrzScan1.dob.Text, "dd-MM-yy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                    int myAge = ((TimeSpan)(DateTime.Today - myDOB)).Days / 365;
                    mrzScan1.age.Text = myAge.ToString();
                }
                catch (Exception) {
                    mrzScan1.age.Text = "ERROR READING AGE";
                };
            }
            #endregion //iC<>deiDesign Fixing the reported DOB issue here 'cause I dont want to touch the former code

            #region //iC<>deiDesign Attempting to fix data callback error for some passports
            if (mrzScan1.doe_flag.BackColor == Color.White)
            { //iC<>deiDesign 
                //MessageBox.Show("Attempting datacallback error fix");
                
                DateTime myExp = new DateTime(1960, 10, 1);
                try
                {
                    myExp = DateTime.ParseExact(mrzScan1.doe.Text, "dd-MM-yy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                }
                catch (Exception) { }

                if (myExp.Year != 1960)
                { //meaning a valid date has been read into the textbox

                    Boolean isDocValid = DateTime.Compare(myExp, DateTime.Today) > 0 ? true : false;

                    if (isDocValid)
                    {
                        btnSV_doe = true;
                        mrzScan1.doe_flag.Text = "OK";
                        mrzScan1.doe_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                    } else {
                        btnSV_doe = false;
                        mrzScan1.doe_flag.Text = "ERROR";
                        mrzScan1.doe_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                    };

                    //MessageBox.Show("datacallback error fix successful!");
                };

            };
            #endregion //iC<>deiDesign Attempting to fix data callback error for some passports
        }

        void EventCallbackThreadHelper(MMM.Readers.FullPage.EventCode aEventType)
        {
            if (_threadHelperControl.InvokeRequired)
            {
                _threadHelperControl.Invoke(
                    new MMM.Readers.FullPage.EventDelegate(EventCallback),
                    new object[] { aEventType }
                );
            }
            else
            {
                EventCallback(aEventType);
            }
        }

        private bool enabledRFID = false;
        public bool HasEnabledRFID {
            get { return enabledRFID; }
            set { this.enabledRFID = value; }
        }
        string saved_name = "";
        bool hasSavedName = false;
        void EventCallback(MMM.Readers.FullPage.EventCode aEventType)
        {

            try
            {
                LogEvent(aEventType);

                switch (aEventType)
                {
                    case MMM.Readers.FullPage.EventCode.SETTINGS_INITIALISED:
                        {
                            // You may wish to change the settings immediately after they have 
                            // been loaded - for example, to turn off options that you do not 
                            // want.
                            MMM.Readers.FullPage.ReaderSettings lSettings;
                            MMM.Readers.ErrorCode errorCode = MMM.Readers.FullPage.Reader.GetSettings(
                                out lSettings
                            );

                            if (errorCode == MMM.Readers.ErrorCode.NO_ERROR_OCCURRED)
                            {

                                if (HasEnabledRFID)
                                {

                                    //if (settings.puCameraSettings.puSplitImage == false)
                                    //this.tabControl.Controls.Remove(this.ImagesRearTab);

                                    lSettings.puDataToSend.send |=
                                        MMM.Readers.FullPage.DataSendSet.Flags.DOCMARKERS |
                                        MMM.Readers.FullPage.DataSendSet.Flags.SECURITYCHECK;


                                    lSettings.puImageSettings.checkVisibleOcr = true;

                                    DataToSend dataToSend = new DataToSend();
                                    dataToSend.doMagic();
                                    dataToSend.RFIDOption.Checked = true;
                                    dataToSend.checkBoxEPASSPORT.Checked = true;
                                    dataToSend.doMagic2();

                                }

                                else {
                                    //if (settings.puCameraSettings.puSplitImage == false)
                                    //this.tabControl.Controls.Remove(this.ImagesRearTab);

                                    lSettings.puDataToSend.send |=
                                        MMM.Readers.FullPage.DataSendSet.Flags.DOCMARKERS |
                                        MMM.Readers.FullPage.DataSendSet.Flags.SECURITYCHECK;

                                    lSettings.puImageSettings.checkVisibleOcr = true;

                                    //settings.puDataToSend.special =
                                    //MMM.Readers.FullPage.DataSendSet.Flags.VISIBLEIMAGE |
                                    //MMM.Readers.FullPage.DataSendSet.Flags.IRIMAGE;

                                    lSettings.puDataToSend.special |= MMM.Readers.FullPage.DataSendSet.Flags.SECURITYCHECK;

                                    MMM.Readers.FullPage.Reader.UpdateSettings(lSettings);
                                }


                                MMM.Readers.FullPage.Reader.EnableLogging(
                                true,
                                lSettings.puLoggingSettings.logLevel,
                                (int)lSettings.puLoggingSettings.logMask,
                                "HLNonBlockingExample.Net.log"
                                );
                            }
                            else
                            {
                                MessageBox.Show(
                                    "GetSettings failure, check for Settings " +
                                    "structure mis-match. Error: " +
                                    errorCode.ToString(),
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                            }

                            break;
                        }
                    case MMM.Readers.FullPage.EventCode.DOC_ON_WINDOW:
                        {
                            timer2.Stop();
                            timer3.Stop();
                            prDocStartTime = System.DateTime.UtcNow;
                            Clear();


                            break;
                        }
                    case MMM.Readers.FullPage.EventCode.PLUGINS_INITIALISED:
                        {
                            //int lIndex = 0;
                            //string lPluginName = "";

                            //while (
                            //    MMM.Readers.FullPage.Reader.GetPluginName(
                            //        ref lPluginName,
                            //        lIndex
                            //    ) == MMM.Readers.ErrorCode.NO_ERROR_OCCURRED &&
                            //    lPluginName.Length > 0
                            //)
                            //{
                            //    ListViewItem thisItem = TimingsList.Items.Add(
                            //        System.DateTime.UtcNow.ToLongTimeString()
                            //    );
                            //    thisItem.SubItems.Add("Plugin Found");
                            //    thisItem.SubItems.Add("");
                            //    thisItem.SubItems.Add(lPluginName);
                            //    ++lIndex;

                            //    //							//Example of how to enable a plugin
                            //    //							MMM.Readers.FullPage.Reader.EnablePlugin(
                            //    //								lPluginName,
                            //    //								true
                            //    //							);
                            //}
                            break;
                        }
                    case MMM.Readers.FullPage.EventCode.END_OF_DOCUMENT_DATA:
                        {
                            //p codeline match doesn't have a say : in determining showVerification
                            if (this.doc_type.Text.Trim().ToString().ToLower().Contains("passport") && mrzScan1.richTextBoxCodeline.Text.Trim().Equals(rfidScan1.codelineRichTextBox.Text.Trim()) && rfidScan1.codelineRichTextBox.Text.Length > 1)
                            {
                                mrzScan1.cdm_flag.Text = "YES";
                                mrzScan1.cdm_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                            }
                            else if (this.doc_type.Text.Trim().ToString().ToLower().Contains("passport") && !mrzScan1.richTextBoxCodeline.Text.Trim().Equals(rfidScan1.codelineRichTextBox.Text.Trim()) && rfidScan1.codelineRichTextBox.Text.Length > 1)
                            {
                                mrzScan1.cdm_flag.Text = "NO";
                                mrzScan1.cdm_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                            }
                            else if (this.doc_type.Text.Trim().ToString().ToLower().Contains("passport") && rfidScan1.codelineRichTextBox.Text.Length < 1)
                            {
                                mrzScan1.cdm_flag.Text = "NO READ";
                                mrzScan1.cdm_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                            }
                            else {
                                mrzScan1.cdm_flag.Text = "NO READ";
                                mrzScan1.cdm_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                            }

                            //rfid_flag doesn't have a say : in determining showVerification
                            if (rfidScan1.chipID.Text.Length > 1 || theresColorChange() || rfidScan1.codelineRichTextBox.Text.Length > 1)
                            {
                                mrzScan1.rfid_flag.Text = "YES";
                                mrzScan1.rfid_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                            }
                            else {
                                mrzScan1.rfid_flag.Text = "NO";
                                mrzScan1.rfid_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                            }

                            /*
                            //date_of_expiry, checksum, valid_doc and 7 rfid validation attributes.
                            if (btnSV_doe && btnSV_checks && btnSV_valid && sa_ && pa_ && ca_ && si_ && aa_ && ta_ && docsc_)
                            {
                                timer2.Start();
                            }
                            else
                            {
                                timer3.Start();
                            }
                            */

                            #region //iC<>deiDesign //Quick Approach To Address One Of The CheckList Request, I simply commented the code above, then modified it to give what I have in this region
                            if ((btnSV_doe && btnSV_checks && btnSV_valid && sa_ && pa_ && ca_ && si_ && aa_ && ta_ && docsc_) || (btnSV_doe && btnSV_checks && btnSV_valid)) {


                                #region Dealing with the new request concerning passport about to expire (6 months notification), I recently added for the normal notification since the former code isn't providing the accurate response
                                try
                                {
                                    int myDaysToExpiration = ((TimeSpan)(DateTime.ParseExact(mrzScan1.doe.Text, "dd-MM-yy", System.Globalization.DateTimeFormatInfo.InvariantInfo) - DateTime.Today)).Days;

                                    if (myDaysToExpiration / 30 < 6) {
                                        mrzScan1.expired_txt.Text = "Document will expire in less than 6 months (Precisely " + ((int)(myDaysToExpiration % 365) / 30).ToString() + " Months and " + (myDaysToExpiration % 30).ToString() + " Days)";
                                        mrzScan1.expired_txt.ForeColor = Color.PaleVioletRed;
                                    }
                                    else //I decided to write this else to overwrite his (former dev) own message because I noticed his display text in the "DataCallback" event isn't accurate for some reasons I'm not interested in looking into
                                    {
                                        mrzScan1.expired_txt.Text = "Document Expires in " + ((int)(myDaysToExpiration / 365)).ToString() + " Years " + ((int)(myDaysToExpiration % 365) / 30).ToString() + " Months " + (myDaysToExpiration % 30).ToString() + " Days";
                                    };
                                    
                                    String newExpiredText = mrzScan1.expired_txt.Text; //This variable will be finetuned in the next region, if neccessary, and will be used as the final output for the user

                                    #region Formatting the "newExpiredText" var properly to avoid pluralizing singular values
                                    /*A simple inbuilt ".Replace" would have sufficed, like this;
                                        =============================================================================================================================================
                                        mrzScan1.expired_txt.Text = mrzScan1.expired_txt.Text.Replace("1 Years", "1 Year").Replace("1 Months", "1 Month").Replace("1 Days", "1 Day");
                                        =============================================================================================================================================
                                     But I wanted to be a little bit detailed in my text rendering
                                     To avoid having values like 10 Day or 21 Day when it should have Days,
                                     And also, I had used the one below, values like 20 Days or any other ending with zero would have vanished leaving it with just 2
                                        ===========================================================================================================================
                                        mrzScan1.expired_txt.Text = mrzScan1.expired_txt.Text.Replace("0 Years", "").Replace("0 Months", "").Replace("0 Days", "");
                                        ===========================================================================================================================
                                     I actually could have written a more explanatory algo by declaring variables
                                     to store my day, month and year and then check their value but I just don't like to go that route
                                    */
                                    for (int j = 19; j < mrzScan1.expired_txt.Text.Length; j++) {
                                        if (j + 7 <= mrzScan1.expired_txt.Text.Length) {
                                            if (mrzScan1.expired_txt.Text.Substring(j, 7) == "0 Years" && mrzScan1.expired_txt.Text.Substring(j - 1, 1) == " ") {
                                                newExpiredText = newExpiredText.Replace("0 Years", "");
                                            };
                                            if (mrzScan1.expired_txt.Text.Substring(j, 7) == "1 Years" && mrzScan1.expired_txt.Text.Substring(j - 1, 1) == " ") {
                                                newExpiredText = newExpiredText.Replace("1 Years", "1 Year");
                                            };
                                        };

                                        if (j + 8 <= mrzScan1.expired_txt.Text.Length) {
                                            if (mrzScan1.expired_txt.Text.Substring(j, 8) == "0 Months" && mrzScan1.expired_txt.Text.Substring(j - 1, 1) == " ") {
                                                newExpiredText = newExpiredText.Replace("0 Months", "");
                                            };
                                            if (mrzScan1.expired_txt.Text.Substring(j, 8) == "1 Months" && mrzScan1.expired_txt.Text.Substring(j - 1, 1) == " ") {
                                                newExpiredText = newExpiredText.Replace("1 Months", "1 Month");
                                            };
                                        };

                                        if (j + 6 <= mrzScan1.expired_txt.Text.Length) {
                                            if (mrzScan1.expired_txt.Text.Substring(j, 6) == "0 Days" && mrzScan1.expired_txt.Text.Substring(j - 1, 1) == " ") {
                                                newExpiredText = newExpiredText.Replace("0 Days", "");
                                            };
                                            if (mrzScan1.expired_txt.Text.Substring(j, 6) == "1 Days" && mrzScan1.expired_txt.Text.Substring(j - 1, 1) == " ") {
                                                newExpiredText = newExpiredText.Replace("1 Days", "1 Day");
                                            };
                                        };

                                    };
                                    #endregion Formatting the "newExpiredText" var properly to avoid pluralizing singular values

                                    mrzScan1.expired_txt.Text = newExpiredText.Replace("  ", " ");
                                    timer2.Start();

                                } catch (Exception) {
                                    timer3.Start();
                                };
                                #endregion Dealing with the new request concerning passport about to expire (6 months notification), I recently added for the normal notification since the former code isn't providing the accurate response

                            }
                            else {
                                timer3.Start();
                            };
                            #endregion //iC<>deiDesign //Quick Approach To Address One Of The CheckList Request, I simply commented the code above, then modified it to give what I have in this region

                            //System.TimeSpan duration = (System.DateTime.UtcNow - prDocStartTime);
                            //float docTime = duration.Ticks / System.TimeSpan.TicksPerSecond;
                            //statusBar.Panels[1].Text =
                            //"Time: " + docTime.ToString() + "s";

                            //if (MMM.Readers.FullPage.Reader.GetState() != MMM.Readers.FullPage.ReaderState.READER_DISABLED)
                            //{
                            //    MMM.Readers.FullPage.Reader.SetState(MMM.Readers.FullPage.ReaderState.READER_DISABLED, false);
                            //}

                            if (this.doc_type.Text.ToUpper().Equals("UNKNOWN DOCUMENT") || this.doc_type.Text.ToUpper().Contains("UNKNOWN") || this.doc_type.Text.Length < 1)
                            {
                                UpdateScanType updateScanType = new UpdateScanType();
                                updateScanType.ShowDialog();
                                this.doc_type.Text = updateScanType.ScanType;
                                if (updateScanType.pressedCancel)
                                {
                                    this.cancel_btn.PerformClick();
                                }
                                else {
                                    if (this.doc_type.Text.Length > 1)
                                    {
                                        string now_time = DateTime.Now.ToString("HH:mm:ss:f"); //gives time in 24h
                                        storedRecordName = record_folder_name;
                                        if (hasStoredRecoredName)
                                        {
                                            CreateRecordDirectory(flight, storedRecordName, "Scans");
                                        }
                                        else
                                        {
                                            record_folder_name = "Record" + "_" + now_time.Replace(":", "#");
                                            CreateRecordDirectory(flight, record_folder_name, "Scans");
                                            hasStoredRecoredName = true;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("You must enter the document name",
                                                                        "Error Report",
                                                                        MessageBoxButtons.OK,
                                                                        MessageBoxIcon.Information,
                                                                        MessageBoxDefaultButton.Button1,
                                                                        MessageBoxOptions.RightAlign,
                                                                        false);
                                    }
                                }

                            }
                            else
                            {
                                string now_time = DateTime.Now.ToString("HH:mm:ss:f"); //gives time in 24h
                                storedRecordName = record_folder_name;
                                if (hasStoredRecoredName)
                                {
                                    CreateRecordDirectory(flight, storedRecordName, "Scans");
                                }
                                else
                                {
                                    record_folder_name = "Record" + "_" + now_time.Replace(":", "#");
                                    CreateRecordDirectory(flight, record_folder_name, "Scans");
                                    hasStoredRecoredName = true;
                                }

                            }

                            if (!hasSavedName) {
                                if (mrzScan1.family_name.Text.Length > 1 && !mrzScan1.family_name.Text.Contains("*"))
                                {
                                    this.passenger_name.Visible = true;
                                    saved_name = mrzScan1.family_name.Text.ToString() + " " + mrzScan1.given_names.Text.ToString();
                                    this.passenger_name.Text = saved_name;
                                    hasSavedName = true;
                                }
                            }
                            break;
                        }
                }

                state_tview.Text = MMM.Readers.FullPage.Reader.GetState().ToString();
            }
            catch (Exception e)
            {
                LogError(0, e.Message);
            }

        }

        void ErrorCallbackThreadHelper(
            MMM.Readers.ErrorCode aErrorCode,
            string aErrorMessage
        )
        {
            if (_threadHelperControl.InvokeRequired)
            {
                _threadHelperControl.Invoke(
                    new MMM.Readers.ErrorDelegate(ErrorCallback),
                    new object[] { aErrorCode, aErrorMessage }
                );
            }
            else
            {
                ErrorCallback(aErrorCode, aErrorMessage);
            }
        }

        void ErrorCallback(MMM.Readers.ErrorCode aErrorCode, string aErrorMessage)
        {
            LogError(aErrorCode, aErrorMessage);
        }

        void WarningCallbackThreadHelper(
            MMM.Readers.WarningCode aWarningCode,
            string aWarningMessage
        )
        {
            if (_threadHelperControl.InvokeRequired)
            {
                _threadHelperControl.Invoke(
                    new MMM.Readers.WarningDelegate(WarningCallback),
                    new object[] { aWarningCode, aWarningMessage }
                );
            }
            else
            {
                WarningCallback(aWarningCode, aWarningMessage);
            }
        }

        void WarningCallback(MMM.Readers.WarningCode aWarningCode, string aWarningMessage)
        {
            LogWarning(aWarningCode, aWarningMessage);
        }

        bool CertificateCallbackThreadHelper(
            byte[] aCertIdentifier,
            MMM.Readers.Modules.RF.CertType aCertType,
            out byte[] aCertBuffer
        )
        {
            if (_threadHelperControl.InvokeRequired)
            {
                aCertBuffer = null;
                object[] lParams = new object[]
                {
                    aCertIdentifier, aCertType, aCertBuffer
                };
                bool lResult = (bool)_threadHelperControl.Invoke(
                    new MMM.Readers.FullPage.CertificateDelegate(CertificateCallback),
                    lParams
                    );

                aCertBuffer = (byte[])lParams[2];

                return lResult;
            }
            else
            {
                return CertificateCallback(aCertIdentifier, aCertType, out aCertBuffer);
            }
        }

        bool CertificateCallback(
            byte[] aCertIdentifier,
            MMM.Readers.Modules.RF.CertType aCertType,
            out byte[] aCertBuffer
        )
        {
            bool lSuccess = false;
            OpenFileDialog fileSelector = new OpenFileDialog();
            aCertBuffer = null;

            //aCertType determines what data is held in aCertIdentifier
            switch (aCertType)
            {
                case MMM.Readers.Modules.RF.CertType.CT_CERTIFICATE_REVOCATION_LIST:
                    //ASN.1 DER Encoded Issuer and Serial Number
                    break;
                case MMM.Readers.Modules.RF.CertType.CT_COUNTRY_SIGNER_CERT:
                    //ASN.1 DER Encoded Authority Key Identifier
                    break;
                case MMM.Readers.Modules.RF.CertType.CT_DOC_SIGNER_CERT:
                    //ASN.1 DER Encoded SignerIdentifier
                    break;
                case MMM.Readers.Modules.RF.CertType.CT_CVCA_CERT:
                //Country Verifier Certificate Authority Reference (CV CAR) ascii string
                case MMM.Readers.Modules.RF.CertType.CT_DV_CERT:
                //Document Verifier Certificate Authority Reference (DV CAR) ascii string
                case MMM.Readers.Modules.RF.CertType.CT_IS_CERT:
                //Insepction System Certificate Authority Reference (IS CAR) ascii string
                case MMM.Readers.Modules.RF.CertType.CT_AT_CERT:
                //Authentication Terminal Certificate Authority Reference (AT CAR) ascii string
                case MMM.Readers.Modules.RF.CertType.CT_IS_PRIVATE_KEY:
                    //Inspection System Certificate Holder Reference (IS CHR) ascii string
                    break;

            }

            fileSelector.Title = "Open external certificate: " + aCertType.ToString();
            fileSelector.InitialDirectory = "c:\\certs\\";
            fileSelector.Filter = "Certs and keys|*.cer;*.der;*.cvcert;*.pkcs8;*.bin|All files (*.*)|*.*";
            fileSelector.FilterIndex = 1;
            fileSelector.RestoreDirectory = true;

            if (fileSelector.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.IO.Stream fs = null;
                    if ((fs = fileSelector.OpenFile()) != null)
                    {
                        aCertBuffer = new byte[fs.Length];
                        fs.Read(aCertBuffer, 0, aCertBuffer.Length);
                        fs.Close();
                        lSuccess = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

            return lSuccess;
        }

        bool SignRequestCallbackThreadHelper(
            byte[] aBufferToSign,
            byte[] aCertificateBuffer,
            MMM.Readers.Modules.RF.CertType aCertType,
            out byte[] aSignature
        )
        {
            if (_threadHelperControl.InvokeRequired)
            {
                aSignature = null;
                object[] lParams = new object[]
                        {
                            aBufferToSign,
                            aCertificateBuffer,
                            aCertType,
                            aSignature
                        };
                bool lResult = (bool)_threadHelperControl.Invoke(
                    new MMM.Readers.FullPage.SignRequestDelegate(SignRequestCallback),
                    lParams
                    );

                aSignature = (byte[])lParams[3];
                return lResult;
            }
            else
            {
                return SignRequestCallback(
                    aBufferToSign,
                    aCertificateBuffer,
                    aCertType,
                    out aSignature
                    );
            }
        }

        bool SignRequestCallback(
            byte[] aBufferToSign,
            byte[] aCertificateBuffer,
            MMM.Readers.Modules.RF.CertType aCertType,
            out byte[] aSignature
        )
        {
            bool lSuccess = false;
            aSignature = null;

            MessageBox.Show(
                "SignRequestCallback Type: " + aCertType.ToString() +
                " Cert Buffer Len: " + System.Convert.ToString(aCertificateBuffer.Length),
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1
                );

            //-Decode aCertificateBuffer
            //-Read certificate reference
            //-Sign aBufferToSign with relevant key
            //-Fill aSignature with the signature bytes
            //-Return success

            return lSuccess;
        }

        void LogDataItem(MMM.Readers.FullPage.DataType aDataType, object aData)
        {
            Console.WriteLine("Log DataItem(aDataType)");
            if (aDataType == MMM.Readers.FullPage.DataType.CD_SWIPE_MSR_DATA)
            {
                MMM.Readers.Modules.Swipe.MsrData msrData =
                    (MMM.Readers.Modules.Swipe.MsrData)aData;

                LogDataItem("MSR_TRACK_1", msrData.Track1);
                LogDataItem("MSR_TRACK_2", msrData.Track2);
                LogDataItem("MSR_TRACK_3", msrData.Track3);
            }
            else if (aDataType == MMM.Readers.FullPage.DataType.CD_AAMVA_DATA)
            {
                MMM.Readers.AAMVAData aamvaData = (MMM.Readers.AAMVAData)aData;

                LogDataItem("AAMVA_FULL_NAME", aamvaData.Parsed.FullName);
                LogDataItem("AAMVA_LICENCE_NUMBER", aamvaData.Parsed.LicenceNumber);
            }
            else if (aDataType > MMM.Readers.FullPage.DataType.CD_PLUGIN)
            {
                // Here is a generic example of getting data out of a plugin
                MMM.Readers.FullPage.PluginData pluginData =
                    (MMM.Readers.FullPage.PluginData)aData;

                //richTextBoxCodeline.Text = pluginData.puData;
                //ListViewItem thisItem = dataFileList.Items.Add(pluginData.puDataFormat.ToString());

                string lInfo =
                    pluginData.puFeatureName + " " + pluginData.puFieldName + ": ";
                if (pluginData.puData is string)
                    LogDataItem(
                        aDataType.ToString(),
                        lInfo + (string)pluginData.puData
                    );
                else if (pluginData.puData is byte[])
                    LogDataItem(
                        aDataType.ToString(),
                        lInfo + ((byte[])pluginData.puData).Length + " bytes"
                    );
                else
                    LogDataItem(aDataType.ToString(), lInfo + aData);
            }
            else
            {
                LogDataItem(aDataType.ToString(), aData);
            }
        }
        void LogDataItem(string aDataType, object aData)
        {
            Console.WriteLine("Log DataItem");
            System.TimeSpan duration = (System.DateTime.UtcNow - prDocStartTime);
            float dataItemTime = duration.Ticks / System.TimeSpan.TicksPerSecond;
        }

        void LogEvent(MMM.Readers.FullPage.EventCode aEventType)
        {
            Console.WriteLine("Log Event" + aEventType.ToString());
            if (aEventType == MMM.Readers.FullPage.EventCode.READER_CONNECTED)
            {
                connected_tview.Visible = true;
                not_connected_tview.Visible = false;
            }

            if (aEventType == MMM.Readers.FullPage.EventCode.READER_DISCONNECTED) {
                connected_tview.Visible = false;
                not_connected_tview.Visible = true;
            }

            if (aEventType == MMM.Readers.FullPage.EventCode.DIRT_DETECTED_ON_SCANNER_WINDOW) {
                MessageBox.Show(
                "Dirt is detected Scanner Window. Please refer to technical support for more details",
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1
                );
            }
            if (aEventType == MMM.Readers.FullPage.EventCode.DOC_ON_WINDOW) {
                last_event_tview.Text = "Document is on Window";
            }

            if (aEventType == MMM.Readers.FullPage.EventCode.RF_CHIP_OPENED_SUCCESSFULLY) {
                last_event_tview.Text = "RF Chip open SUCCESS";
            }

            if (aEventType == MMM.Readers.FullPage.EventCode.READER_STATE_CHANGED) {
                state_tview.Text = MMM.Readers.FullPage.Reader.GetState().ToString();
            }

            if (aEventType == MMM.Readers.FullPage.EventCode.START_OF_DOCUMENT_DATA)
            {
                last_event_tview.Text = "Start of document data";
            }

            if (aEventType == MMM.Readers.FullPage.EventCode.END_OF_DOCUMENT_DATA) {
                last_event_tview.Text = "End of document data";
            }

            if (aEventType == MMM.Readers.FullPage.EventCode.RF_CHIP_OPEN_TIMEOUT) {
                last_event_tview.Text = "RF Chip open TIMEOUT";
            }

            if (aEventType == MMM.Readers.FullPage.EventCode.RF_CHIP_OPEN_FAILED)
            {
                last_event_tview.Text = "RF Chip open FAILED";
            }
        }

        void LogError(MMM.Readers.ErrorCode aErrorCode, string aErrorMessage)
        {
            Console.WriteLine("Log Error" + aErrorMessage.ToString());
            File.WriteAllText("C:/TravelPass Files/log files/ERR-" + DateTime.Now.ToString("HH:mm:ss:f").Replace(":", "#") + ".txt", aErrorMessage.ToString());
           
            //ListViewItem thisItem = TimingsList.Items.Add(System.DateTime.UtcNow.ToLongTimeString());
            //thisItem.SubItems.Add(aErrorCode.ToString());
            //thisItem.SubItems.Add("");
            //thisItem.SubItems.Add(aErrorMessage);
        }

        void LogWarning(MMM.Readers.WarningCode aWarningCode, string aWarningMessage)
        {
            Console.WriteLine("Log Warning");
            //ListViewItem thisItem = TimingsList.Items.Add(System.DateTime.UtcNow.ToLongTimeString());
            //thisItem.SubItems.Add(aWarningCode.ToString());
            //thisItem.SubItems.Add("");
            //thisItem.SubItems.Add(aWarningMessage);
        }

        protected System.DateTime prDocStartTime = System.DateTime.UtcNow;

        private void InitialiseTimer2(object sender, EventArgs e)
        {
            if (mrzScan1.showVerification.Text.Length > 1)
            {
                mrzScan1.showVerification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
                mrzScan1.showVerification.Text = "";
            }
            else
            {
                mrzScan1.showVerification.Text = "PASSED";
                mrzScan1.showVerification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            }
        }

        private void InitialiseTimer3(object sender, EventArgs e)
        {
            if (mrzScan1.showVerification.Text.Length > 1)
            {
                mrzScan1.showVerification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                mrzScan1.showVerification.Text = "";
            }
            else
            {
                mrzScan1.showVerification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                mrzScan1.showVerification.Text = "FAILED";
            }

        }

        private void InitialiseTimer(object sender, System.EventArgs e)
        {
            timer1.Stop();
            Console.WriteLine("okok");

            try
            {
                MMM.Readers.FullPage.Reader.EnableLogging(
                    true,
                    1,
                    -1,
                    "HLNonBlockingExample.Net.log"
                );

                prDocStartTime = System.DateTime.UtcNow;

                // Thread helper delegates are used to avoid thread-safety issues, particularly 
                // with .NET framework 2.0				
                MMM.Readers.ErrorCode lResult = MMM.Readers.ErrorCode.NO_ERROR_OCCURRED;

                Microsoft.Win32.SystemEvents.PowerModeChanged += new Microsoft.Win32.PowerModeChangedEventHandler(OnPowerModeChanged);

                lResult = MMM.Readers.FullPage.Reader.Initialise(
                    new MMM.Readers.FullPage.DataDelegate(DataCallbackThreadHelper),
                    new MMM.Readers.FullPage.EventDelegate(EventCallbackThreadHelper),
                    new MMM.Readers.ErrorDelegate(ErrorCallbackThreadHelper),
                    new MMM.Readers.FullPage.CertificateDelegate(CertificateCallbackThreadHelper),
                    true,
                    false
                );
                //MMM.Readers.Modules.Imaging.PerformSecurityCheck()

                if (lResult != MMM.Readers.ErrorCode.NO_ERROR_OCCURRED)
                {
                    MessageBox.Show(
                        "Initialise failed - " + lResult.ToString(),
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1
                        );
                }
                MMM.Readers.FullPage.Reader.SetWarningCallback(new MMM.Readers.WarningDelegate(WarningCallbackThreadHelper));


                //			//Example of how to set the signrequest callback
                //			MMM.Readers.FullPage.Reader.SetSignRequestCallback(
                //				SignRequestCallbackThreadHelper
                //			);
            }
            catch (System.DllNotFoundException except)
            {
                MessageBox.Show(
                    except.Message +
                    "\nEnsure the \"working directory\" of the application is set to the " +
                    "Page Reader\\bin folder. When run within the IDE, set this through " +
                    "Properties -> Configuration Properties -> Debugging"
                );
            }
        }

        private MMM.Readers.FullPage.ReaderState prPreviousState = MMM.Readers.FullPage.ReaderState.READER_ENABLED;
        private void OnPowerModeChanged(object sender, Microsoft.Win32.PowerModeChangedEventArgs e)
        {
            switch (e.Mode)
            {
                case Microsoft.Win32.PowerModes.Resume:
                    // delay before starting up as the USB subsystem seems to take a while to startup.
                    // If you don't delay, things will recover via the error recovery system, but you'll
                    // get some "access denied" errors from USB devices until it is fully started.
                    System.Threading.Thread.Sleep(5000);
                    MMM.Readers.FullPage.Reader.SetState(prPreviousState, true);
                    state_tview.Text = prPreviousState.ToString();
                    break;

                case Microsoft.Win32.PowerModes.Suspend:
                    {
                        // signal that we want to change state
                        MMM.Readers.FullPage.ReaderState lCurrentState
                             = MMM.Readers.FullPage.Reader.GetState();
                        prPreviousState = lCurrentState;

                        if ((lCurrentState != MMM.Readers.FullPage.ReaderState.READER_NOT_INITIALISED) &&
                            (lCurrentState != MMM.Readers.FullPage.ReaderState.READER_ERRORED) &&
                            (lCurrentState != MMM.Readers.FullPage.ReaderState.READER_TERMINATED) &&
                            (lCurrentState != MMM.Readers.FullPage.ReaderState.READER_SUSPENDED))
                        {
                            MMM.Readers.FullPage.Reader.SetState(
                                MMM.Readers.FullPage.ReaderState.READER_SUSPENDED,
                                true
                                );

                            state_tview.Text = MMM.Readers.FullPage.ReaderState.READER_SUSPENDED.ToString();

                            // Wait for the state change to be applied
                            do
                            {
                                System.Threading.Thread.Sleep(10);
                                lCurrentState = MMM.Readers.FullPage.Reader.GetState();
                            }
                            while (lCurrentState == prPreviousState);
                        }
                    }
                    break;
            }
        }

        private void AddRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                MMM.Readers.FullPage.Reader.Shutdown();
            }
            catch (DllNotFoundException ex)
            {
                // only happens in the case where you started without MMMReaderHighLevelAPI.dll in the search path
            }
        }

        private void AddRecord_Load(object sender, EventArgs e)
        {
            // we wont actually do the initialisation in load so that the window opens before we do it, as it can take a while.
            timer1.Start();

        }

        private void not_connected_tview_Click(object sender, EventArgs e)
        {

        }

        private void Clear() {
            mrzScan1.mrzImage.Image = null;
            viewImages1.visImage.Image = null;
            viewImages1.irImage.Image = null;
            viewImages1.uvImage.Image = null;

            mrzScan1.richTextBoxCodeline.Text = "";
            doc_type.Text = "";
            mrzScan1.doc_no.Text = "";
            mrzScan1.family_name.Text = "";
            mrzScan1.given_names.Text = "";
            mrzScan1.sex.Text = "";
            mrzScan1.dob.Text = "";
            mrzScan1.nationality.Text = "";
            mrzScan1.issuer.Text = "";
            mrzScan1.doe.Text = "";
            mrzScan1.expired_txt.Text = "";
            mrzScan1.age.Text = "";

            isPostDated   = false;
            visaStartDate = DateTime.MinValue;

            timer2.Stop();
            timer3.Stop();
            mrzScan1.showVerification.BackColor = Color.White;
            mrzScan1.doc_no_flag.BackColor = Color.White;
            mrzScan1.dob_flag.BackColor = Color.White;
            mrzScan1.doe_flag.BackColor = Color.White;
            mrzScan1.vd_flag.BackColor = Color.White;
            mrzScan1.checks_flag.BackColor = Color.White;
            mrzScan1.flagged_flag.BackColor = Color.White;
            mrzScan1.oid_flag.BackColor = Color.White;
            mrzScan1.rfid_flag.BackColor = Color.White;
            mrzScan1.cdm_flag.BackColor = Color.White;

            rfidScan1.rfImage.Image = null;
            rfidScan1.dg1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));

            rfidScan1.dg_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg_5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg_6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg_7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg_8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg_9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg_10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg_11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg_12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg_13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg_14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg_15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.dg_16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            rfidScan1.codelineRichTextBox.Text = "";
            rfidScan1.chipID.Text = "";
            rfidScan1.caImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
            rfidScan1.docsImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
            rfidScan1.taImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
            rfidScan1.aaImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
            rfidScan1.siImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
            rfidScan1.saImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;
            rfidScan1.paImage.Image = global::TravelPass.Properties.Resources.if_file_blank_paper_page_document_3209256;

            passenger_name.Text = "";

            //this.expiry_flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));

            //t_mrz.Text = "";
            //t_vis.Text = "";
            //t_ir.Text = "";
            //t_uv.Text = "";
        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void StoreRFIDOrder(ref MMM.Readers.FullPage.RFIDDataToSend aDataToSend)
        {
            string[] str_array = new string[] { "DG1 MRZ",
                                                "DG1 file",
                                                "DG1 validate",
                                                "Validate Signature",
                                                "Validate Signed Attrs",
                                                "DG2 Photo",
                                                "DG2 file",
                                                "DG2 validate",
                                                "Active Authentication",
                                                "BAC Status",
                                                "SAC Status",
                                                "EF.COM file",
                                                "EF.SOD file",
                                                "Air Baud Rate",
                                                "Validate D/S Cert.",
                                                "Chip ID",
                                                "DG1 Data eDL",
                                                "DG3 Fingerprints",
                                                "DG6 eDL Photo",
                                                "DG7 eDL Fingerprints",
                                                "Crosscheck EF.COM / EF.SOD",
                                                "DG3 file",
                                                "DG3 validate",
                                                "DG4 file",
                                                "DG4 validate",
                                                "DG5 file",
                                                "DG5 validate",
                                                "DG6 file",
                                                "DG6 validate",
                                                "DG7 file",
                                                "DG7 validate",
                                                "DG8 file",
                                                "DG8 validate",
                                                "DG9 file",
                                                "DG9 validate",
                                                "DG10 file",
                                                "DG10 validate",
                                                "DG11 file",
                                                "DG11 validate",
                                                "DG12 file",
                                                "DG12 validate",
                                                "DG13 file",
                                                "DG13 validate",
                                                "DG14 file",
                                                "DG14 validate",
                                                "DG15 file",
                                                "DG15 validate",
                                                "DG16 file",
                                                "DG16 validate",
                                                "DG1_eID file",
                                                "DG1_eID validate",
                                                "DG2_eID file",
                                                "DG2_eID validate",
                                                "DG3_eID file",
                                                "DG3_eID validate",
                                                "DG4_eID file",
                                                "DG4_eID validate",
                                                "DG5_eID file",
                                                "DG5_eID validate",
                                                "DG6_eID file",
                                                "DG6_eID validate",
                                                "DG7_eID file",
                                                "DG7_eID validate",
                                                "DG8_eID file",
                                                "DG8_eID validate",
                                                "DG9_eID file",
                                                "DG9_eID validate",
                                                "DG10_eID file",
                                                "DG10_eID validate",
                                                "DG11_eID file",
                                                "DG11_eID validate",
                                                "DG12_eID file",
                                                "DG12_eID validate",
                                                "DG13_eID file",
                                                "DG13_eID validate",
                                                "DG14_eID file",
                                                "DG14_eID validate",
                                                "DG15_eID file",
                                                "DG15_eID validate",
                                                "DG16_eID file",
                                                "DG16_eID validate",
                                                "DG17_eID file",
                                                "DG17_eID validate",
                                                "DG18_eID file",
                                                "DG18_eID validate",
                                                "DG19_eID file",
                                                "DG19_eID validate",
                                                "DG20_eID file",
                                                "DG20_eID validate",
                                                "DG21_eID file",
                                                "DG21_eID validate",
                                                "DG22_eID file",
                                                "DG22_eID validate",
                                                "DG1_eDL file",
                                                "DG1_eDL validate",
                                                "DG2_eDL file",
                                                "DG2_eDL validate",
                                                "DG3_eDL file",
                                                "DG3_eDL validate",
                                                "DG4_eDL file",
                                                "DG4_eDL validate",
                                                "DG5_eDL file",
                                                "DG5_eDL validate",
                                                "DG6_eDL file",
                                                "DG6_eDL validate",
                                                "DG7_eDL file",
                                                "DG7_eDL validate",
                                                "DG8_eDL file",
                                                "DG8_eDL validate",
                                                "DG9_eDL file",
                                                "DG9_eDL validate",
                                                "DG10_eDL file",
                                                "DG10_eDL validate",
                                                "DG11_eDL file",
                                                "DG11_eDL validate",
                                                "DG12_eDL file",
                                                "DG12_eDL validate",
                                                "DG13_eDL file",
                                                "DG13_eDL validate",
                                                "DG14_eDL file",
                                                "DG14_eDL validate"};
            // To avoid having this switch twice, we'll just go around this for both list controls with a loop.
            // For the available list control, we want to set the order number to 0 for all items in it. For the
            // selected list control, we want to set the order number to the index in the list, plus 1.
            for (int lIndex = 0; lIndex < str_array.Length; lIndex++)
            {
                if (!(str_array[lIndex] is String))
                    continue;

                int lOrder = lIndex + 1;
                String lItem = str_array[lIndex] as String;
                Console.WriteLine("lOrder = " + lOrder);

                if (lItem == "EF.COM file")
                    aDataToSend.puEFComFile = lOrder;

                else if (lItem == "EF.SOD file")
                    aDataToSend.puEFSodFile = lOrder;

                else if (lItem == "Air Baud Rate")
                    aDataToSend.puAirBaudRate = lOrder;

                else if (lItem == "Active Authentication")
                    aDataToSend.puActiveAuthentication = lOrder;

                else if (lItem == "Validate D/S Cert.")
                    aDataToSend.puValidateDocSignerCert = lOrder;

                else if (lItem == "Chip ID")
                    aDataToSend.puChipID = lOrder;

                else if (lItem == "DG1 MRZ")
                    aDataToSend.puDG1MRZData = lOrder;

                else if (lItem == "DG1 Data eDL")
                    aDataToSend.puDG1DataEDL = lOrder;

                else if (lItem == "DG2 Photo")
                    aDataToSend.puDG2FaceJPEG = lOrder;

                else if (lItem == "DG3 Fingerprints")
                    aDataToSend.puDG3Fingerprints = lOrder;

                else if (lItem == "DG6 eDL Photo")
                    aDataToSend.puDG6FaceJPEG = lOrder;

                else if (lItem == "DG7 eDL Fingerprints")
                    aDataToSend.puDG7Fingerprints = lOrder;

                else if (lItem == "Crosscheck EF.COM / EF.SOD")
                    aDataToSend.puCrosscheckEFComEFSod = lOrder;

                else if (lItem == "Validate Signature")
                    aDataToSend.puValidateSignature = lOrder;

                else if (lItem == "Validate Signed Attrs")
                    aDataToSend.puValidateSignedAttrs = lOrder;

                else if (lItem == "BAC Status")
                    aDataToSend.puGetBACStatus = lOrder;

                else if (lItem == "SAC Status")
                    aDataToSend.puGetSACStatus = lOrder;

                else if (lItem.Contains("DG") && !(lItem.Contains("_eID") || lItem.Contains("_eDL")))
                {
                    String lDGString = "";
                    foreach (Char lChar in lItem)
                    {
                        if (Char.IsNumber(lChar))
                            lDGString += lChar;
                    }
                    int lDataGroup = Int32.Parse(lDGString);

                    if (lItem.Contains("file") && lDataGroup <= aDataToSend.puDGFile.Length)
                        aDataToSend.puDGFile[lDataGroup] = lOrder;
                    else if (lItem.Contains("validate") && lDataGroup <= aDataToSend.puDGFile.Length)
                        aDataToSend.puValidateDG[lDataGroup] = lOrder;
                }

                else if (lItem.Contains("_eID"))
                {
                    String lDGString = "";
                    foreach (Char lChar in lItem)
                    {
                        if (Char.IsNumber(lChar))
                            lDGString += lChar;
                    }
                    int lDataGroup = Int32.Parse(lDGString);

                    if (lItem.Contains("file") && lDataGroup <= aDataToSend.puDGFileEID.Length)
                        aDataToSend.puDGFileEID[lDataGroup] = lOrder;
                    else if (lItem.Contains("validate") && lDataGroup <= aDataToSend.puDGFileEID.Length)
                        aDataToSend.puValidateDGEID[lDataGroup] = lOrder;
                }
                else if (lItem.Contains("_eDL"))
                {
                    String lDGString = "";
                    foreach (Char lChar in lItem)
                    {
                        if (Char.IsNumber(lChar))
                            lDGString += lChar;
                    }
                    int lDataGroup = Int32.Parse(lDGString);

                    if (lItem.Contains("file") && lDataGroup <= aDataToSend.puDGFileEDL.Length)
                        aDataToSend.puDGFileEDL[lDataGroup] = lOrder;
                    else if (lItem.Contains("validate") && lDataGroup <= aDataToSend.puDGFileEDL.Length)
                        aDataToSend.puValidateDGEDL[lDataGroup] = lOrder;
                }
            }
        }

        private void mrz_scan_Click(object sender, EventArgs e)
        {
            mrzScan1.BringToFront();
        }

        private void view_images_Click(object sender, EventArgs e)
        {
            viewImages1.BringToFront();
        }
        DataToSend dataToSend = new DataToSend();
        private void InitialiseTimer4(object sender, System.EventArgs e) {

            dataToSend.doMagic();
            dataToSend.RFIDOption.Checked = true;
            dataToSend.checkBoxEPASSPORT.Checked = true;
            dataToSend.doMagic2();
        }

        private void InitialiseTimer5(object sender, System.EventArgs e) {
            dataToSend.doMagic2();
        }

        private void rfid_scan_Click(object sender, EventArgs e)
        {
            rfidScan1.BringToFront();
        }

        private void adjust_settings_Click(object sender, EventArgs e)
        {
            DataToSend dataToSend = new DataToSend();
            dataToSend.ShowDialog();
        }


        public void do_Func_afterSave() {
            timer1.Start();

        }

        private bool jps = false;
        public bool jpsave {
            get { return jps; }
            set { this.jps = value; }
        }

        private string flight_from_str = "";
        public String Flight_From {
            get { return flight_from_str; }
            set { this.flight_from_str = value; }
        }

        private string flight_to_str = "";
        public String Flight_To {
            get { return flight_to_str; }
            set { this.flight_to_str = value; }
        }

        private string flight_class;
        public String Flight_Class {
            get { return flight_class; }
            set { this.flight_class = value; }
        }

        private void AddRecord_Shown(object sender, EventArgs e)
        {
            flight_from.Text = flight_from_str;
            flight_to.Text = flight_to_str;
            class_combo.Text = flight_class;
            //do_something
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            Console.WriteLine(appPath);

            //flight_airports data setup
            var collection_of_objects =
                (from line in File.ReadAllLines("airports.dat").Skip(1)
                 let parts = line.Split(',')
                 select new
                 {
                     airport_name = parts[1],
                     airport_country = parts[3],
                     airport_code = parts[4],
                 }
                ).ToList();
            Console.WriteLine("first airport name is = " + collection_of_objects[0].airport_name);
            string[] airport_data = new string[collection_of_objects.Count];

            for (int i = 0; i < collection_of_objects.Count; i++)
            {
                airport_data[i] = collection_of_objects[i].airport_code.Trim(new Char[] { '"' }) + "-" + collection_of_objects[i].airport_name.Trim(new Char[] { '"' });
                try
                {
                    hashtable.Add(airport_data[i].ToString().Trim(), collection_of_objects[i].airport_country.ToString().Trim());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                 
                }
            }
            Console.WriteLine("length of airport data is = " + airport_data.Length);
            flight_from.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            flight_from.AutoCompleteCustomSource.AddRange(airport_data);
            flight_to.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            flight_to.AutoCompleteCustomSource.AddRange(airport_data);
            final_dest.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            final_dest.AutoCompleteCustomSource.AddRange(airport_data);
        }

        private Flight flight;
        public Flight Flight_ {
            get { return flight; }
            set { this.flight = value; }
        }

        public String STORED_RECORD_NAME {
            get { return record_folder_name; }
            set { this.record_folder_name = value; }
        }

        public bool HAS_STORED_RECORD_NAME {
            get { return hasStoredRecoredName; }
            set { this.hasStoredRecoredName = value; }
        }

        private void save_scan_Click(object sender, EventArgs e)
        {
            //if (!(mrzScan1.doc_no.TextLength < 1) || !(viewImages1.visImage.Image == null))end_of
            //{
                if (this.final_dest.TextLength < 1)
                {
                    MessageBox.Show("Error!!!. Please enter Final Destination",
                                        "Error Report",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error,
                                        MessageBoxDefaultButton.Button1,
                                        MessageBoxOptions.RightAlign,
                                        false);
                }
                else
                {
                    if (this.doc_type.Text.ToUpper().Equals("UNKNOWN DOCUMENT") || this.doc_type.Text.ToUpper().Contains("UNKNOWN") || this.doc_type.Text.Length < 1)
                    {
                        UpdateScanType updateScanType = new UpdateScanType();
                        updateScanType.ShowDialog();
                        this.doc_type.Text = updateScanType.ScanType;
                    if (updateScanType.pressedCancel)
                    {
                        this.cancel_btn.PerformClick();
                    }
                    else {
                        if (this.doc_type.Text.Length > 1)
                        {
                            if (!(mrzScan1.doc_no.TextLength < 1) || !(viewImages1.visImage.Image == null))
                            {
                                if (this.final_dest.TextLength < 1)
                                {
                                    MessageBox.Show("Error saving scan. Please enter Final Destination for this Record",
                                                        "Error Report",
                                                        MessageBoxButtons.OK,
                                                        MessageBoxIcon.Error,
                                                        MessageBoxDefaultButton.Button1,
                                                        MessageBoxOptions.RightAlign,
                                                        false);
                                }
                                else
                                {
                                    string now_time = DateTime.Now.ToString("HH:mm:ss:f"); //gives time in 24h
                                    storedRecordName = record_folder_name;
                                    if (hasStoredRecoredName)
                                    {
                                        CreateRecordDirectory(flight, storedRecordName, "Scans");
                                    }
                                    else
                                    {
                                        record_folder_name = "Record" + "_" + now_time.Replace(":", "#");
                                        CreateRecordDirectory(flight, record_folder_name, "Scans");
                                        hasStoredRecoredName = true;
                                    }
                                }
                            }
                            else
                            {
                                DialogResult dResult_ = MessageBox.Show("ERROR!!! No scan attached",
                                                                                "Error Report",
                                                                                MessageBoxButtons.OK,
                                                                                MessageBoxIcon.Error,
                                                                                MessageBoxDefaultButton.Button1,
                                                                                MessageBoxOptions.RightAlign,
                                                                                false);
                                //if (dResult_ == DialogResult.OK)
                                //{
                                //Clear();
                                //}
                            }
                        }
                    }
                    
                    
                    }
                    else
                    {
                        string now_time = DateTime.Now.ToString("HH:mm:ss:f"); //gives time in 24h
                        storedRecordName = record_folder_name;
                        if (hasStoredRecoredName)
                        {
                            CreateRecordDirectory(flight, storedRecordName, "Scans");
                        }
                        else
                        {
                            record_folder_name = "Record" + "_" + now_time.Replace(":", "#");
                            CreateRecordDirectory(flight, record_folder_name, "Scans");
                            hasStoredRecoredName = true;
                        }

                    }
                }
            //}
            //else {
              //  DialogResult dResult_ = MessageBox.Show("ERROR!!! No scan attached",
                //                                                "Error Report",
                  //                                              MessageBoxButtons.OK,
                    //                                            MessageBoxIcon.Error,
                      //                                          MessageBoxDefaultButton.Button1,
                        //                                        MessageBoxOptions.RightAlign,
                          //                                      false);
                //if (dResult_ == DialogResult.OK)
                //{
                    //Clear();
                //}
            //}
        }

        private bool just_hit_done = false;
        public bool JUST_HIT_DONE {
            get { return just_hit_done; }
            set { this.just_hit_done = value; }
        }

        private string user_email;
        public String User_Email
        {
            get { return user_email; }
            set { this.user_email = value; }
        }

        private string fullname;
        public String Fullname
        {
            get { return fullname; }
            set { this.fullname = value; }
        }

        private void CreateRecordDirectory(Flight flight, string record_folder_name, string doc_scan_folder_name)
        { 
            try
            {
                string ffn = flight.FolderName;
                string recordsFolderPathString = "";
                if (ffn.Contains("\""))
                {
                    recordsFolderPathString = System.IO.Path.Combine(ffn.Replace("\"", "") /**folder path**/, "Records");
                    System.IO.Directory.CreateDirectory(recordsFolderPathString);
                }
                else
                {
                    recordsFolderPathString = System.IO.Path.Combine(flight.FolderName /**folder path**/, "Records");
                    System.IO.Directory.CreateDirectory(recordsFolderPathString);
                }
                string recordFolderPathString = System.IO.Path.Combine(recordsFolderPathString /**folder path**/, record_folder_name);
                System.IO.Directory.CreateDirectory(recordFolderPathString);
                string docScanFolderPathString = System.IO.Path.Combine(recordFolderPathString, doc_scan_folder_name);
                System.IO.Directory.CreateDirectory(docScanFolderPathString);
                string recordDetailsPathString = System.IO.Path.Combine(recordFolderPathString, "Record Details.travlr");
                if (!File.Exists(recordDetailsPathString))
                {
                    string[] rlines = {"***Record Details***",
                        "Record Folder Path = " + @"" + "\"" + recordFolderPathString + "\"",
                        "Recorded by_Name = " + fullname,
                        "Recorded by_Email = " + user_email,
                        "Scanned Passport Number = " + mrzScan1.doc_no.Text.ToString(),
                        /* "Scanned Passport Name = " + passenger_name.Text.ToString(), */ 
                        "Scanned Passport Name = " + mrzScan1.family_name.Text + " " + mrzScan1.given_names.Text,
                        "Date-Time Recorded = " + DateTime.Now.ToString("dd MMM yyyy HH:mm:ss"),
                        "Flight From = " + this.flight_from.Text.ToString(),
                        "Flight To = " + this.flight_to.Text.ToString(),
                        "Final Destination = " + this.final_dest.Text.ToString(),
                        "Class = " + this.class_combo.Text.ToString(),
                        "Hand Luggagge = " + this.hl_box.Text.ToString(),
                        "Check In Luggagge = " + this.cil_box.Text.ToString()
                    };
                    using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(recordDetailsPathString))
                    {
                        foreach (string line in rlines)
                        {
                            file.WriteLine(line);
                        }
                    }
                }
                else {
                    string[] rlines = {"###Records Update Details###",
                        "Record Folder Path = " + @"" + "\"" + recordFolderPathString + "\"",
                        "Updated by_Name = " + fullname,
                        "Updated by_Email = " + user_email,
                        "Scanned Passport Number = " + mrzScan1.doc_no.Text.ToString(),
                        /* "Scanned Passport Name = " + passenger_name.Text.ToString(), */
                        "Scanned Passport Name = " + mrzScan1.family_name.Text + " " + mrzScan1.given_names.Text,
                        "Date-Time Updated = " + DateTime.Now.ToString("dd MMM yyyy HH:mm:ss"),
                        "Flight From = " + this.flight_from.Text.ToString(),
                        "Flight To = " + this.flight_to.Text.ToString(),
                        "Final Destination = " + this.final_dest.Text.ToString(),
                        "Class = " + this.class_combo.Text.ToString(),
                        "Hand Luggagge = " + this.hl_box.Text.ToString(),
                        "Check In Luggagge = " + this.cil_box.Text.ToString()
                    };
                    using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(recordDetailsPathString, append:true))
                    {
                        foreach (string line in rlines)
                        {
                            file.WriteLine(line); //just applied this breakpoint to see what's being written by myself (17/6/2025)
                        }
                    }
                }

                // Auto-update search index so Smart Search reflects new record immediately.
                try
                {
                    string flightsRoot = System.IO.Directory.GetParent(
                        System.IO.Directory.GetParent(recordsFolderPathString).FullName).FullName;
                    RecordIndex.AddOrUpdateEntry(recordFolderPathString, flightsRoot);
                }
                catch { }



                if (this.doc_type.Text.ToUpper().Equals("PASSPORT"))
                {
                    string passportFolderPathString = System.IO.Path.Combine(docScanFolderPathString, "Passport_" + mrzScan1.doc_no.Text.Replace("*", "").ToString() + "_" + DateTime.Now.ToString("HH:mm:ss:f").Replace(":", "#")/**Passport_A04898745_11#11#11#1**/);
                    System.IO.Directory.CreateDirectory(passportFolderPathString);
                    string passportDetailsPathString = System.IO.Path.Combine(passportFolderPathString, "Passport Validation Details.travlr");
                    string[] lines = {"***Passport Validation Details***",
                            "Passport Number = " + mrzScan1.doc_no.Text.ToString(),
                            "Passed = " + PassportPassedVerified(),
                            "Document No = " + mrzScan1.doc_no_flag.Text.ToString(),
                            "Date of birth = " + mrzScan1.dob_flag.Text.ToString(),
                            "Date of expiry = " + mrzScan1.doe_flag.Text.ToString(),
                            "Optional ID = " + mrzScan1.oid_flag.Text.ToString(),
                            "Valid Document = " + mrzScan1.vd_flag.Text.ToString(),
                            "Global CheckSum = " + mrzScan1.checks_flag.Text.ToString(),
                            "P Codeline Match = " + mrzScan1.cdm_flag.Text.ToString(),
                            "RFID availability = " + mrzScan1.rfid_flag.Text.ToString(),
                            "isFlagged = " + isPersonnelFlagged(mrzScan1.flagged_flag.Text.Trim().ToString()) /**need to still get back here**/
                    }; 
                    using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(passportDetailsPathString))
                    {
                        foreach (string line in lines)
                        {
                            file.WriteLine(line);
                        }
                    }
                    string mrzscanFolderPathString = System.IO.Path.Combine(passportFolderPathString, "MRZ Scan");
                    System.IO.Directory.CreateDirectory(mrzscanFolderPathString);
                    string mrzscanCodelineDetailsPathString = System.IO.Path.Combine(mrzscanFolderPathString, "MRZ Codeline Details.travlr");
                    //if (!System.IO.File.Exists(mrzscanCodelineDetailsPathString))
                    //{
                        string[] lines_ = {"***MRZ Codeline Details***",
                            "Document Number = " + mrzScan1.doc_no.Text.ToString(),
                            "Family Name = " + mrzScan1.family_name.Text.ToString(),
                            "Given Names = " + mrzScan1.given_names.Text.ToString(),
                            "Sex = " + mrzScan1.sex.Text.ToString(),
                            "Date of birth = " + mrzScan1.dob.Text.ToString(),
                            "Age = " + mrzScan1.age.Text.ToString(),
                            "Nationality = " + mrzScan1.nationality.Text.ToString(),
                            "Date of expiry = " + mrzScan1.doe.Text.ToString(),
                            "Issuer = " + mrzScan1.issuer.Text.ToString(),
                            "Codeline = " + mrzScan1.richTextBoxCodeline.Text.ToString(),
                            "Optional Data = " + mrzScan1.opt_data.Text.ToString(),
                            "Image Location = " + mrzscanFolderPathString + @"\View Images\MRZImage.jpeg"
                        };
                        using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(mrzscanCodelineDetailsPathString))
                        {
                            foreach (string line in lines_)
                            {
                                file.WriteLine(line);
                            }
                        }
                        string viewImagesFolderPathString = System.IO.Path.Combine(mrzscanFolderPathString, "View Images");
                        System.IO.Directory.CreateDirectory(viewImagesFolderPathString);
                    try
                    {
                        mrzScan1.mrzImage.Image.Save(@"" + viewImagesFolderPathString.Trim().ToString() + @"\MRZImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(enabledRFID.ToString());
                    }

                    try
                    {
                        viewImages1.visImage.Image.Save(@"" + viewImagesFolderPathString.Trim().ToString() + @"\VISImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    try
                    {
                        viewImages1.irImage.Image.Save(@"" + viewImagesFolderPathString.Trim().ToString() + @"\IRImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    try
                    {
                        viewImages1.uvImage.Image.Save(@"" + viewImagesFolderPathString.Trim().ToString() + @"\UVImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    if (rfidScan1.codelineRichTextBox.TextLength > 1)
                        {
                            string rfidscanFolderPathString = System.IO.Path.Combine(passportFolderPathString, "RFID Scan");
                            System.IO.Directory.CreateDirectory(rfidscanFolderPathString);
                            string rfidscanDetailsPathString = System.IO.Path.Combine(rfidscanFolderPathString, "RFID Scan Details.travlr");
                            if (!System.IO.File.Exists(rfidscanDetailsPathString))
                            {
                                string[] lines__ = {"***RFID Scan Details***",
                            rfidScan1.chipID.Text.ToString(),
                            ">>>Data groups",
                            "READ SECTION",
                            "DG1 = " + RFIDDatagroupVerified(rfidScan1.dg1.BackColor),
                            "DG2 = " + RFIDDatagroupVerified(rfidScan1.dg2.BackColor),
                            "DG3 = " + RFIDDatagroupVerified(rfidScan1.dg3.BackColor),
                            "DG4 = " + RFIDDatagroupVerified(rfidScan1.dg4.BackColor),
                            "DG5 = " + RFIDDatagroupVerified(rfidScan1.dg5.BackColor),
                            "DG6 = " + RFIDDatagroupVerified(rfidScan1.dg6.BackColor),
                            "DG7 = " + RFIDDatagroupVerified(rfidScan1.dg7.BackColor),
                            "DG8 = " + RFIDDatagroupVerified(rfidScan1.dg8.BackColor),
                            "DG9 = " + RFIDDatagroupVerified(rfidScan1.dg9.BackColor),
                            "DG10 = " + RFIDDatagroupVerified(rfidScan1.dg10.BackColor),
                            "DG11 = " + RFIDDatagroupVerified(rfidScan1.dg11.BackColor),
                            "DG12 = " + RFIDDatagroupVerified(rfidScan1.dg12.BackColor),
                            "DG13 = " + RFIDDatagroupVerified(rfidScan1.dg13.BackColor),
                            "DG14 = " + RFIDDatagroupVerified(rfidScan1.dg14.BackColor),
                            "DG15 = " + RFIDDatagroupVerified(rfidScan1.dg15.BackColor),
                            "DG16 = " + RFIDDatagroupVerified(rfidScan1.dg16.BackColor),
                            "VALIDATED SECTION",
                            "DG1 = " + RFIDDatagroupVerified(rfidScan1.dg_1.BackColor),
                            "DG2 = " + RFIDDatagroupVerified(rfidScan1.dg_2.BackColor),
                            "DG3 = " + RFIDDatagroupVerified(rfidScan1.dg_3.BackColor),
                            "DG4 = " + RFIDDatagroupVerified(rfidScan1.dg_4.BackColor),
                            "DG5 = " + RFIDDatagroupVerified(rfidScan1.dg_5.BackColor),
                            "DG6 = " + RFIDDatagroupVerified(rfidScan1.dg_6.BackColor),
                            "DG7 = " + RFIDDatagroupVerified(rfidScan1.dg_7.BackColor),
                            "DG8 = " + RFIDDatagroupVerified(rfidScan1.dg_8.BackColor),
                            "DG9 = " + RFIDDatagroupVerified(rfidScan1.dg_9.BackColor),
                            "DG10 = " + RFIDDatagroupVerified(rfidScan1.dg_10.BackColor),
                            "DG11 = " + RFIDDatagroupVerified(rfidScan1.dg_11.BackColor),
                            "DG12 = " + RFIDDatagroupVerified(rfidScan1.dg_12.BackColor),
                            "DG13 = " + RFIDDatagroupVerified(rfidScan1.dg_13.BackColor),
                            "DG14 = " + RFIDDatagroupVerified(rfidScan1.dg_14.BackColor),
                            "DG15 = " + RFIDDatagroupVerified(rfidScan1.dg_15.BackColor),
                            "DG16 = " + RFIDDatagroupVerified(rfidScan1.dg_16.BackColor),
                            "\n",
                            ">>> ATTRIBUTES VALIDATION",
                            "Signed Attributes = " + signed_attrs,
                            "Passive Auth = " + passive_auth,
                            "Chip Auth = " + chip_auth,
                            "Signature = " + sign_,
                            "Active Auth = " + active_auth,
                            "Terminal Auth = " + term_auth,
                            "Doc Signer Cert = " + doc_signer_cert,
                            "\n",
                            "Codeline = " + rfidScan1.codelineRichTextBox.Text.ToString()
                        };
                                Console.WriteLine(rfidScan1.saImage.ImageLocation);
                                using (System.IO.StreamWriter file =
                                    new System.IO.StreamWriter(rfidscanDetailsPathString))
                                {
                                    foreach (string line in lines__)
                                    {
                                        file.WriteLine(line);
                                    }
                                }
                            try
                            {
                                rfidScan1.rfImage.Image.Save(rfidscanFolderPathString.Replace("\"", "").Trim() + @"\RFIDImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                            }
                            catch (Exception ex) {
                                Console.WriteLine(ex.ToString());
                            }
                            }
                        }
                        
                    //}
                    //DialogResult dResult_ = MessageBox.Show("Scan saved successfully",
                    //                                            "Success Report",
                    //                                            MessageBoxButtons.OK,
                    //                                            MessageBoxIcon.Information,
                    //                                            MessageBoxDefaultButton.Button1,
                    //                                            MessageBoxOptions.RightAlign,
                    //                                            false);
                    //if (dResult_ == DialogResult.OK) {
                    //    Clear();
                    //}

                    //if (dResult_ == DialogResult.OK)
                    //{
                    //    AddAdditionalScan addAdditionalScan = new AddAdditionalScan();
                    //    addAdditionalScan.ShowDialog();
                    //    if (addAdditionalScan.isDonePressed)
                    //    {
                    //        just_hit_done = true;
                    //        this.Close();
                    //    }
                    //}


                }

                else if (this.doc_type.Text.ToUpper().Equals("VISA"))
                {
                    string visaFolderPathString = System.IO.Path.Combine(docScanFolderPathString, "Visa_" + mrzScan1.doc_no.Text.Replace("*", "").ToString() + "_" + DateTime.Now.ToString("HH:mm:ss:f").Replace(":", "#")/**Visa_A04898745_11#11#11#1**/);
                    System.IO.Directory.CreateDirectory(visaFolderPathString);
                    string visaDetailsPathString = System.IO.Path.Combine(visaFolderPathString, "Visa Validation Details.travlr");
                    string[] vlines = {"***Visa Validation Details***",
                        "Passport Number = " + mrzScan1.doc_no.Text.ToString(),
                        "Passed = " + (PassportPassedVerified() && !isPostDated),
                        "Document No = " + mrzScan1.doc_no_flag.Text.ToString(),
                        "Date of birth = " + mrzScan1.dob_flag.Text.ToString(),
                        "Date of expiry = " + mrzScan1.doe_flag.Text.ToString(),
                        "Optional ID = " + mrzScan1.oid_flag.Text.ToString(),
                        "Valid Document = " + mrzScan1.vd_flag.Text.ToString(),
                        "Global CheckSum = " + mrzScan1.checks_flag.Text.ToString(),
                        "P Codeline Match = " + mrzScan1.cdm_flag.Text.ToString(),
                        "RFID availability = " + mrzScan1.rfid_flag.Text.ToString(),
                        "isFlagged = " + isPersonnelFlagged(mrzScan1.flagged_flag.Text.Trim().ToString()),
                        "Visa Start Date = " + (visaStartDate != DateTime.MinValue ? visaStartDate.ToString("dd MMM yyyy") : "UNKNOWN"),
                        "isPostDated = " + isPostDated
                    };
                    using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(visaDetailsPathString))
                    {
                        foreach (string line in vlines)
                        {
                            file.WriteLine(line);
                        }
                    }
                    string mrzscanFolderPathString = System.IO.Path.Combine(visaFolderPathString, "MRZ Scan");
                    System.IO.Directory.CreateDirectory(mrzscanFolderPathString);
                    string mrzscanCodelineDetailsPathString = System.IO.Path.Combine(mrzscanFolderPathString, "MRZ Codeline Details.travlr");
                    //if (!System.IO.File.Exists(mrzscanCodelineDetailsPathString))
                    //{
                        string[] vlines_ = {"***MRZ Codeline Details***",
                            "Document Number = " + mrzScan1.doc_no.Text.ToString(),
                            "Family Name = " + mrzScan1.family_name.Text.ToString(),
                            "Given Names = " + mrzScan1.given_names.Text.ToString(),
                            "Sex = " + mrzScan1.sex.Text.ToString(),
                            "Date of birth = " + mrzScan1.dob.Text.ToString(),
                            "Age = " + mrzScan1.age.Text.ToString(),
                            "Nationality = " + mrzScan1.nationality.Text.ToString(),
                            "Date of expiry = " + mrzScan1.doe.Text.ToString(),
                            "Issuer = " + mrzScan1.issuer.Text.ToString(),
                            "Codeline = " + mrzScan1.richTextBoxCodeline.Text.ToString(),
                            "Optional Data = " + mrzScan1.opt_data.Text.ToString(),
                            "Image Location = " + mrzscanFolderPathString + @"\View Images\MRZImage.jpeg"
                        };
                        using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(mrzscanCodelineDetailsPathString))
                        {
                            foreach (string line in vlines_)
                            {
                                file.WriteLine(line);
                            }
                        }
                        string viewImagesFolderPathString = System.IO.Path.Combine(mrzscanFolderPathString, "View Images");
                        System.IO.Directory.CreateDirectory(viewImagesFolderPathString);
                    try
                    {
                        mrzScan1.mrzImage.Image.Save(@"" + viewImagesFolderPathString.Trim().ToString() + @"\MRZImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(enabledRFID.ToString());
                    }

                    try
                    {
                        viewImages1.visImage.Image.Save(@"" + viewImagesFolderPathString.Trim().ToString() + @"\VISImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    try
                    {
                        viewImages1.irImage.Image.Save(@"" + viewImagesFolderPathString.Trim().ToString() + @"\IRImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    try
                    {
                        viewImages1.uvImage.Image.Save(@"" + viewImagesFolderPathString.Trim().ToString() + @"\UVImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    if (rfidScan1.codelineRichTextBox.TextLength > 1)
                        {
                            string rfidscanFolderPathString = System.IO.Path.Combine(visaFolderPathString, "RFID Scan");
                            System.IO.Directory.CreateDirectory(rfidscanFolderPathString);
                            string rfidscanDetailsPathString = System.IO.Path.Combine(rfidscanFolderPathString, "RFID Scan Details.travlr");
                            if (!System.IO.File.Exists(rfidscanDetailsPathString))
                            {
                                string[] lines__ = {"***RFID Scan Details***",
                            rfidScan1.chipID.Text.ToString(),
                            ">>>Data groups",
                            "READ SECTION",
                            "DG1 = " + RFIDDatagroupVerified(rfidScan1.dg1.BackColor),
                            "DG2 = " + RFIDDatagroupVerified(rfidScan1.dg2.BackColor),
                            "DG3 = " + RFIDDatagroupVerified(rfidScan1.dg3.BackColor),
                            "DG4 = " + RFIDDatagroupVerified(rfidScan1.dg4.BackColor),
                            "DG5 = " + RFIDDatagroupVerified(rfidScan1.dg5.BackColor),
                            "DG6 = " + RFIDDatagroupVerified(rfidScan1.dg6.BackColor),
                            "DG7 = " + RFIDDatagroupVerified(rfidScan1.dg7.BackColor),
                            "DG8 = " + RFIDDatagroupVerified(rfidScan1.dg8.BackColor),
                            "DG9 = " + RFIDDatagroupVerified(rfidScan1.dg9.BackColor),
                            "DG10 = " + RFIDDatagroupVerified(rfidScan1.dg10.BackColor),
                            "DG11 = " + RFIDDatagroupVerified(rfidScan1.dg11.BackColor),
                            "DG12 = " + RFIDDatagroupVerified(rfidScan1.dg12.BackColor),
                            "DG13 = " + RFIDDatagroupVerified(rfidScan1.dg13.BackColor),
                            "DG14 = " + RFIDDatagroupVerified(rfidScan1.dg14.BackColor),
                            "DG15 = " + RFIDDatagroupVerified(rfidScan1.dg15.BackColor),
                            "DG16 = " + RFIDDatagroupVerified(rfidScan1.dg16.BackColor),
                            "VALIDATED SECTION",
                            "DG1 = " + RFIDDatagroupVerified(rfidScan1.dg_1.BackColor),
                            "DG2 = " + RFIDDatagroupVerified(rfidScan1.dg_2.BackColor),
                            "DG3 = " + RFIDDatagroupVerified(rfidScan1.dg_3.BackColor),
                            "DG4 = " + RFIDDatagroupVerified(rfidScan1.dg_4.BackColor),
                            "DG5 = " + RFIDDatagroupVerified(rfidScan1.dg_5.BackColor),
                            "DG6 = " + RFIDDatagroupVerified(rfidScan1.dg_6.BackColor),
                            "DG7 = " + RFIDDatagroupVerified(rfidScan1.dg_7.BackColor),
                            "DG8 = " + RFIDDatagroupVerified(rfidScan1.dg_8.BackColor),
                            "DG9 = " + RFIDDatagroupVerified(rfidScan1.dg_9.BackColor),
                            "DG10 = " + RFIDDatagroupVerified(rfidScan1.dg_10.BackColor),
                            "DG11 = " + RFIDDatagroupVerified(rfidScan1.dg_11.BackColor),
                            "DG12 = " + RFIDDatagroupVerified(rfidScan1.dg_12.BackColor),
                            "DG13 = " + RFIDDatagroupVerified(rfidScan1.dg_13.BackColor),
                            "DG14 = " + RFIDDatagroupVerified(rfidScan1.dg_14.BackColor),
                            "DG15 = " + RFIDDatagroupVerified(rfidScan1.dg_15.BackColor),
                            "DG16 = " + RFIDDatagroupVerified(rfidScan1.dg_16.BackColor),
                            "\n",
                            ">>> ATTRIBUTES VALIDATION",
                            "Signed Attributes = " + signed_attrs,
                            "Passive Auth = " + passive_auth,
                            "Chip Auth = " + chip_auth,
                            "Signature = " + sign_,
                            "Active Auth = " + active_auth,
                            "Terminal Auth = " + term_auth,
                            "Doc Signer Cert = " + doc_signer_cert,
                            "\n",
                            "Codeline = " + rfidScan1.codelineRichTextBox.Text.ToString()
                        };
                                Console.WriteLine(rfidScan1.saImage.ImageLocation);
                                using (System.IO.StreamWriter file =
                                    new System.IO.StreamWriter(rfidscanDetailsPathString))
                                {
                                    foreach (string line in lines__)
                                    {
                                        file.WriteLine(line);
                                    }
                                }
                            try {
                                rfidScan1.rfImage.Image.Save(rfidscanFolderPathString.Replace("\"", "").Trim() + @"\RFIDImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);

                            }
                            catch (Exception ex) {
                                Console.WriteLine(ex.ToString());
                            }
                            }
                        }
                    //}

                    //DialogResult dResult_ = MessageBox.Show("Scan saved successfully",
                    //                                            "Success Report",
                    //                                            MessageBoxButtons.OK,
                    //                                            MessageBoxIcon.Information,
                    //                                            MessageBoxDefaultButton.Button1,
                    //                                            MessageBoxOptions.RightAlign,
                    //                                            false);
                    //if (dResult_ == DialogResult.OK) {
                    //    Clear();
                    //}
                    //if (dResult_ == DialogResult.OK)
                    //{
                    //    AddAdditionalScan addAdditionalScan = new AddAdditionalScan();
                    //    addAdditionalScan.ShowDialog();
                    //    if (addAdditionalScan.isDonePressed)
                    //    {
                    //        just_hit_done = true;
                    //        this.Close();
                    //    }
                    //}
                }

                else
                {
                    string udocFolderPathString = System.IO.Path.Combine(docScanFolderPathString, doc_type.Text.ToString() + "_" + DateTime.Now.ToString("HH:mm:ss:f").Replace(":", "#")/**Ticket_DateTimeNow**/);
                    System.IO.Directory.CreateDirectory(udocFolderPathString);
                    string viewImagesFolderPathString = System.IO.Path.Combine(udocFolderPathString, "View Images");
                    System.IO.Directory.CreateDirectory(viewImagesFolderPathString);
                    Console.WriteLine("**********" + @"" + viewImagesFolderPathString.Trim().ToString());
                    try
                    {
                        mrzScan1.mrzImage.Image.Save(@"" + viewImagesFolderPathString.Trim().ToString() + @"\MRZImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(enabledRFID.ToString());
                    }

                    try
                    {
                        viewImages1.visImage.Image.Save(@"" + viewImagesFolderPathString.Trim().ToString() + @"\VISImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    try
                    {
                        viewImages1.irImage.Image.Save(@"" + viewImagesFolderPathString.Trim().ToString() + @"\IRImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    try
                    {
                        viewImages1.uvImage.Image.Save(@"" + viewImagesFolderPathString.Trim().ToString() + @"\UVImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    if (rfidScan1.codelineRichTextBox.TextLength > 1)
                    {
                        string rfidscanFolderPathString = System.IO.Path.Combine(udocFolderPathString, "RFID Scan");
                        System.IO.Directory.CreateDirectory(rfidscanFolderPathString);
                        string rfidscanDetailsPathString = System.IO.Path.Combine(rfidscanFolderPathString, "RFID Scan Details.travlr");
                        string[] lines__ = {"***RFID Scan Details***",
                            rfidScan1.chipID.Text.ToString(),
                            ">>>Data groups",
                            "READ SECTION",
                            "DG1 = " + RFIDDatagroupVerified(rfidScan1.dg1.BackColor),
                            "DG2 = " + RFIDDatagroupVerified(rfidScan1.dg2.BackColor),
                            "DG3 = " + RFIDDatagroupVerified(rfidScan1.dg3.BackColor),
                            "DG4 = " + RFIDDatagroupVerified(rfidScan1.dg4.BackColor),
                            "DG5 = " + RFIDDatagroupVerified(rfidScan1.dg5.BackColor),
                            "DG6 = " + RFIDDatagroupVerified(rfidScan1.dg6.BackColor),
                            "DG7 = " + RFIDDatagroupVerified(rfidScan1.dg7.BackColor),
                            "DG8 = " + RFIDDatagroupVerified(rfidScan1.dg8.BackColor),
                            "DG9 = " + RFIDDatagroupVerified(rfidScan1.dg9.BackColor),
                            "DG10 = " + RFIDDatagroupVerified(rfidScan1.dg10.BackColor),
                            "DG11 = " + RFIDDatagroupVerified(rfidScan1.dg11.BackColor),
                            "DG12 = " + RFIDDatagroupVerified(rfidScan1.dg12.BackColor),
                            "DG13 = " + RFIDDatagroupVerified(rfidScan1.dg13.BackColor),
                            "DG14 = " + RFIDDatagroupVerified(rfidScan1.dg14.BackColor),
                            "DG15 = " + RFIDDatagroupVerified(rfidScan1.dg15.BackColor),
                            "DG16 = " + RFIDDatagroupVerified(rfidScan1.dg16.BackColor),
                            "VALIDATED SECTION",
                            "DG1 = " + RFIDDatagroupVerified(rfidScan1.dg_1.BackColor),
                            "DG2 = " + RFIDDatagroupVerified(rfidScan1.dg_2.BackColor),
                            "DG3 = " + RFIDDatagroupVerified(rfidScan1.dg_3.BackColor),
                            "DG4 = " + RFIDDatagroupVerified(rfidScan1.dg_4.BackColor),
                            "DG5 = " + RFIDDatagroupVerified(rfidScan1.dg_5.BackColor),
                            "DG6 = " + RFIDDatagroupVerified(rfidScan1.dg_6.BackColor),
                            "DG7 = " + RFIDDatagroupVerified(rfidScan1.dg_7.BackColor),
                            "DG8 = " + RFIDDatagroupVerified(rfidScan1.dg_8.BackColor),
                            "DG9 = " + RFIDDatagroupVerified(rfidScan1.dg_9.BackColor),
                            "DG10 = " + RFIDDatagroupVerified(rfidScan1.dg_10.BackColor),
                            "DG11 = " + RFIDDatagroupVerified(rfidScan1.dg_11.BackColor),
                            "DG12 = " + RFIDDatagroupVerified(rfidScan1.dg_12.BackColor),
                            "DG13 = " + RFIDDatagroupVerified(rfidScan1.dg_13.BackColor),
                            "DG14 = " + RFIDDatagroupVerified(rfidScan1.dg_14.BackColor),
                            "DG15 = " + RFIDDatagroupVerified(rfidScan1.dg_15.BackColor),
                            "DG16 = " + RFIDDatagroupVerified(rfidScan1.dg_16.BackColor),
                            "\n",
                            ">>> ATTRIBUTES VALIDATION",
                            "Signed Attributes = " + signed_attrs,
                            "Passive Auth = " + passive_auth,
                            "Chip Auth = " + chip_auth,
                            "Signature = " + sign_,
                            "Active Auth = " + active_auth,
                            "Terminal Auth = " + term_auth,
                            "Doc Signer Cert = " + doc_signer_cert,
                            "\n",
                            "Codeline = " + rfidScan1.codelineRichTextBox.Text.ToString()
                        };
                        Console.WriteLine(rfidScan1.saImage.ImageLocation);
                        using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(rfidscanDetailsPathString))
                        {
                            foreach (string line in lines__)
                            {
                                file.WriteLine(line);
                            }
                        }
                        try
                        {
                            rfidScan1.rfImage.Image.Save(rfidscanFolderPathString.Replace("\"", "").Trim() + @"\RFIDImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);

                        }
                        catch (Exception ex) {
                            Console.WriteLine(ex.ToString());
                        }
                    }


                    //DialogResult dResult = MessageBox.Show("Scan saved successfully",
                    //                                                "Success Report",
                    //                                                MessageBoxButtons.OK,
                    //                                                MessageBoxIcon.Information,
                    //                                                MessageBoxDefaultButton.Button1,
                    //                                                MessageBoxOptions.RightAlign,
                    //                                                false);

                    //if (dResult == DialogResult.OK) {
                    //    Clear(); 
                    //}

                    //if (dResult == DialogResult.OK)
                    //{
                    //    AddAdditionalScan addAdditionalScan = new AddAdditionalScan();
                    //    addAdditionalScan.ShowDialog();
                    //    if (addAdditionalScan.isDonePressed)
                    //    {
                    //        just_hit_done = true;
                    //        this.Close();
                    //    }
                    //}
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                DialogResult dResult = MessageBox.Show("Error saving scan",
                                                            "Error Report",
                                                            MessageBoxButtons.OK,
                                                            MessageBoxIcon.Error,
                                                            MessageBoxDefaultButton.Button1,
                                                            MessageBoxOptions.RightAlign,
                                                            false);
            }
        }

        private bool PassportPassedVerified() {
            if (btnSV_doe && btnSV_checks && btnSV_valid && sa_ && pa_ && ca_ && si_ && aa_ && ta_ && docsc_)
            {
                Console.WriteLine("It passed");
                return true;
            }
            else {
                Console.WriteLine("It failed");
                return false;
            }
        }

        private bool isPersonnelFlagged(string s)
        {
            if (s.Equals("YES"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool RFIDDatagroupVerified(Color color)
        {
            if (System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0))))).Equals(color))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void cancel_scan_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void done_scan_Click(object sender, EventArgs e)
        {
            //if (this.doc_type.Text.ToUpper().Equals("UNKNOWN DOCUMENT") || this.doc_type.Text.ToUpper().Contains("UNKNOWN") || this.doc_type.Text.Length < 1)
            //{
            //    UpdateScanType updateScanType = new UpdateScanType();
            //    updateScanType.ShowDialog();
            //    this.doc_type.Text = updateScanType.ScanType;
            //    if (this.doc_type.Text.Length > 1)
            //    {
            //        string now_time = DateTime.Now.ToString("HH:mm:ss:f"); //gives time in 24h
            //        storedRecordName = record_folder_name;
            //        if (hasStoredRecoredName)
            //        {
            //            CreateRecordDirectory(flight, storedRecordName, "Scans");
            //        }
            //        else
            //        {
            //            record_folder_name = "Record" + "_" + now_time.Replace(":", "#");
            //            CreateRecordDirectory(flight, record_folder_name, "Scans");
            //            hasStoredRecoredName = true;
            //        }
            //    }
            //    else {
            //        MessageBox.Show("You must enter the document name",
            //                                        "Error Report",
            //                                        MessageBoxButtons.OK,
            //                                        MessageBoxIcon.Information,
            //                                        MessageBoxDefaultButton.Button1,
            //                                        MessageBoxOptions.RightAlign,
            //                                        false);
            //    }
            //}
            //else
            //{
            //    string now_time = DateTime.Now.ToString("HH:mm:ss:f"); //gives time in 24h
            //    storedRecordName = record_folder_name;
            //    if (hasStoredRecoredName)
            //    {
            //        CreateRecordDirectory_(flight, storedRecordName, "Scans");
            //    }
            //    else
            //    {
            //        record_folder_name = "Record" + "_" + now_time.Replace(":", "#");
            //        CreateRecordDirectory_(flight, record_folder_name, "Scans");
            //        hasStoredRecoredName = true;
            //    }

            //}
            just_hit_done = true;
            this.Close();
        }

        private void CreateRecordDirectory_(Flight flight, string record_folder_name, string doc_scan_folder_name)
        {
            try
            {
                string ffn = flight.FolderName;
                string recordsFolderPathString = "";
                if (ffn.Contains("\""))
                {
                    recordsFolderPathString = System.IO.Path.Combine(ffn.Replace("\"", "") /**folder path**/, "Records");
                    System.IO.Directory.CreateDirectory(recordsFolderPathString);
                }
                else
                {
                    recordsFolderPathString = System.IO.Path.Combine(flight.FolderName /**folder path**/, "Records");
                    System.IO.Directory.CreateDirectory(recordsFolderPathString);
                }
                string recordFolderPathString = System.IO.Path.Combine(recordsFolderPathString /**folder path**/, record_folder_name);
                System.IO.Directory.CreateDirectory(recordFolderPathString);
                string docScanFolderPathString = System.IO.Path.Combine(recordFolderPathString, doc_scan_folder_name);
                System.IO.Directory.CreateDirectory(docScanFolderPathString);
                string recordDetailsPathString = System.IO.Path.Combine(recordFolderPathString, "Record Details.travlr");
                if (!File.Exists(recordDetailsPathString))
                {
                    string[] rlines = {"***Record Details***",
                        "Record Folder Path = " + @"" + "\"" + recordFolderPathString + "\"",
                        "Recorded by_Name = " + fullname,
                        "Recorded by_Email = " + user_email,
                        "Scanned Passport Number = " + mrzScan1.doc_no.Text.ToString(),
                        "Scanned Passport Name = " + passenger_name.Text.ToString(),
                        "Date-Time Recorded = " + DateTime.Now.ToString("dd MMM yyyy HH:mm:ss"),
                        "Flight From = " + this.flight_from.Text.ToString(),
                        "Flight To = " + this.flight_to.Text.ToString(),
                        "Final Destination = " + this.final_dest.Text.ToString(),
                        "Class = " + this.class_combo.Text.ToString(),
                        "Hand Luggagge = " + this.hl_box.Text.ToString(),
                        "Check In Luggagge = " + this.cil_box.Text.ToString()
                    };
                    using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(recordDetailsPathString))
                    {
                        foreach (string line in rlines)
                        {
                            file.WriteLine(line);
                        }
                    }
                }
                else
                {
                    string[] rlines = {"###Records Update Details###",
                        "Record Folder Path = " + @"" + "\"" + recordFolderPathString + "\"",
                        "Updated by_Name = " + fullname,
                        "Updated by_Email = " + user_email,
                        "Scanned Passport Number = " + mrzScan1.doc_no.Text.ToString(),
                        "Scanned Passport Name = " + passenger_name.Text.ToString(),
                        "Date-Time Updated = " + DateTime.Now.ToString("dd MMM yyyy HH:mm:ss"),
                        "Flight From = " + this.flight_from.Text.ToString(),
                        "Flight To = " + this.flight_to.Text.ToString(),
                        "Final Destination = " + this.final_dest.Text.ToString(),
                        "Class = " + this.class_combo.Text.ToString(),
                        "Hand Luggagge = " + this.hl_box.Text.ToString(),
                        "Check In Luggagge = " + this.cil_box.Text.ToString()
                    };
                    using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(recordDetailsPathString, append: true))
                    {
                        foreach (string line in rlines)
                        {
                            file.WriteLine(line);
                        }
                    }
                }

                // Auto-update search index so Smart Search reflects new record immediately.
                try
                {
                    string flightsRoot = System.IO.Directory.GetParent(
                        System.IO.Directory.GetParent(recordsFolderPathString).FullName).FullName;
                    RecordIndex.AddOrUpdateEntry(recordFolderPathString, flightsRoot);
                }
                catch { }

                if (this.doc_type.Text.ToUpper().Equals("PASSPORT"))
                {
                    string passportFolderPathString = System.IO.Path.Combine(docScanFolderPathString, "Passport_" + mrzScan1.doc_no.Text.Replace("*", "").ToString() + "_" + DateTime.Now.ToString("HH:mm:ss:f").Replace(":", "#")/**Passport_A04898745_11#11#11#1**/);
                    System.IO.Directory.CreateDirectory(passportFolderPathString);
                    string passportDetailsPathString = System.IO.Path.Combine(passportFolderPathString, "Passport Validation Details.travlr");
                    string[] lines = {"***Passport Validation Details***",
                            "Passport Number = " + mrzScan1.doc_no.Text.ToString(),
                            "Passed = " + PassportPassedVerified(),
                            "Document No = " + mrzScan1.doc_no_flag.Text.ToString(),
                            "Date of birth = " + mrzScan1.dob_flag.Text.ToString(),
                            "Date of expiry = " + mrzScan1.doe_flag.Text.ToString(),
                            "Optional ID = " + mrzScan1.oid_flag.Text.ToString(),
                            "Valid Document = " + mrzScan1.vd_flag.Text.ToString(),
                            "Global CheckSum = " + mrzScan1.checks_flag.Text.ToString(),
                            "P Codeline Match = " + mrzScan1.cdm_flag.Text.ToString(),
                            "RFID availability = " + mrzScan1.rfid_flag.Text.ToString(),
                            "isFlagged = " + isPersonnelFlagged(mrzScan1.flagged_flag.Text.Trim().ToString()) /**need to still get back here**/
                    };
                    using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(passportDetailsPathString))
                    {
                        foreach (string line in lines)
                        {
                            file.WriteLine(line);
                        }
                    }
                    string mrzscanFolderPathString = System.IO.Path.Combine(passportFolderPathString, "MRZ Scan");
                    System.IO.Directory.CreateDirectory(mrzscanFolderPathString);
                    string mrzscanCodelineDetailsPathString = System.IO.Path.Combine(mrzscanFolderPathString, "MRZ Codeline Details.travlr");
                    //if (!System.IO.File.Exists(mrzscanCodelineDetailsPathString))
                    //{
                    string[] lines_ = {"***MRZ Codeline Details***",
                            "Document Number = " + mrzScan1.doc_no.Text.ToString(),
                            "Family Name = " + mrzScan1.family_name.Text.ToString(),
                            "Given Names = " + mrzScan1.given_names.Text.ToString(),
                            "Sex = " + mrzScan1.sex.Text.ToString(),
                            "Date of birth = " + mrzScan1.dob.Text.ToString(),
                            "Age = " + mrzScan1.age.Text.ToString(),
                            "Nationality = " + mrzScan1.nationality.Text.ToString(),
                            "Date of expiry = " + mrzScan1.doe.Text.ToString(),
                            "Issuer = " + mrzScan1.issuer.Text.ToString(),
                            "Codeline = " + mrzScan1.richTextBoxCodeline.Text.ToString(),
                            "Optional Data = " + mrzScan1.opt_data.Text.ToString(),
                            "Image Location = " + mrzscanFolderPathString + @"\View Images\MRZImage.jpeg"
                        };
                    using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(mrzscanCodelineDetailsPathString))
                    { 
                        foreach (string line in lines_)
                        {
                            file.WriteLine(line);
                        }
                    }
                    string viewImagesFolderPathString = System.IO.Path.Combine(mrzscanFolderPathString, "View Images");
                    System.IO.Directory.CreateDirectory(viewImagesFolderPathString);
                    try
                    {
                        mrzScan1.mrzImage.Image.Save(@"" + viewImagesFolderPathString.Trim().ToString() + @"\MRZImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex) {
                        Console.WriteLine(enabledRFID.ToString());
                    }

                    try
                    {
                        viewImages1.visImage.Image.Save(@"" + viewImagesFolderPathString.Trim().ToString() + @"\VISImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex.ToString());
                    }

                    try
                    {
                        viewImages1.irImage.Image.Save(@"" + viewImagesFolderPathString.Trim().ToString() + @"\IRImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex.ToString());
                    }

                    try
                    {
                        viewImages1.uvImage.Image.Save(@"" + viewImagesFolderPathString.Trim().ToString() + @"\UVImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex.ToString());
                    }
                    if (rfidScan1.codelineRichTextBox.TextLength > 1)
                    {
                        string rfidscanFolderPathString = System.IO.Path.Combine(passportFolderPathString, "RFID Scan");
                        System.IO.Directory.CreateDirectory(rfidscanFolderPathString);
                        string rfidscanDetailsPathString = System.IO.Path.Combine(rfidscanFolderPathString, "RFID Scan Details.travlr");
                        if (!System.IO.File.Exists(rfidscanDetailsPathString))
                        {
                            string[] lines__ = {"***RFID Scan Details***",
                            rfidScan1.chipID.Text.ToString(),
                            ">>>Data groups",
                            "READ SECTION",
                            "DG1 = " + RFIDDatagroupVerified(rfidScan1.dg1.BackColor),
                            "DG2 = " + RFIDDatagroupVerified(rfidScan1.dg2.BackColor),
                            "DG3 = " + RFIDDatagroupVerified(rfidScan1.dg3.BackColor),
                            "DG4 = " + RFIDDatagroupVerified(rfidScan1.dg4.BackColor),
                            "DG5 = " + RFIDDatagroupVerified(rfidScan1.dg5.BackColor),
                            "DG6 = " + RFIDDatagroupVerified(rfidScan1.dg6.BackColor),
                            "DG7 = " + RFIDDatagroupVerified(rfidScan1.dg7.BackColor),
                            "DG8 = " + RFIDDatagroupVerified(rfidScan1.dg8.BackColor),
                            "DG9 = " + RFIDDatagroupVerified(rfidScan1.dg9.BackColor),
                            "DG10 = " + RFIDDatagroupVerified(rfidScan1.dg10.BackColor),
                            "DG11 = " + RFIDDatagroupVerified(rfidScan1.dg11.BackColor),
                            "DG12 = " + RFIDDatagroupVerified(rfidScan1.dg12.BackColor),
                            "DG13 = " + RFIDDatagroupVerified(rfidScan1.dg13.BackColor),
                            "DG14 = " + RFIDDatagroupVerified(rfidScan1.dg14.BackColor),
                            "DG15 = " + RFIDDatagroupVerified(rfidScan1.dg15.BackColor),
                            "DG16 = " + RFIDDatagroupVerified(rfidScan1.dg16.BackColor),
                            "VALIDATED SECTION",
                            "DG1 = " + RFIDDatagroupVerified(rfidScan1.dg_1.BackColor),
                            "DG2 = " + RFIDDatagroupVerified(rfidScan1.dg_2.BackColor),
                            "DG3 = " + RFIDDatagroupVerified(rfidScan1.dg_3.BackColor),
                            "DG4 = " + RFIDDatagroupVerified(rfidScan1.dg_4.BackColor),
                            "DG5 = " + RFIDDatagroupVerified(rfidScan1.dg_5.BackColor),
                            "DG6 = " + RFIDDatagroupVerified(rfidScan1.dg_6.BackColor),
                            "DG7 = " + RFIDDatagroupVerified(rfidScan1.dg_7.BackColor),
                            "DG8 = " + RFIDDatagroupVerified(rfidScan1.dg_8.BackColor),
                            "DG9 = " + RFIDDatagroupVerified(rfidScan1.dg_9.BackColor),
                            "DG10 = " + RFIDDatagroupVerified(rfidScan1.dg_10.BackColor),
                            "DG11 = " + RFIDDatagroupVerified(rfidScan1.dg_11.BackColor),
                            "DG12 = " + RFIDDatagroupVerified(rfidScan1.dg_12.BackColor),
                            "DG13 = " + RFIDDatagroupVerified(rfidScan1.dg_13.BackColor),
                            "DG14 = " + RFIDDatagroupVerified(rfidScan1.dg_14.BackColor),
                            "DG15 = " + RFIDDatagroupVerified(rfidScan1.dg_15.BackColor),
                            "DG16 = " + RFIDDatagroupVerified(rfidScan1.dg_16.BackColor),
                            "\n",
                            ">>> ATTRIBUTES VALIDATION",
                            "Signed Attributes = " + signed_attrs,
                            "Passive Auth = " + passive_auth,
                            "Chip Auth = " + chip_auth,
                            "Signature = " + sign_,
                            "Active Auth = " + active_auth,
                            "Terminal Auth = " + term_auth,
                            "Doc Signer Cert = " + doc_signer_cert,
                            "\n",
                            "Codeline = " + rfidScan1.codelineRichTextBox.Text.ToString()
                        };
                            Console.WriteLine(rfidScan1.saImage.ImageLocation);
                            using (System.IO.StreamWriter file =
                                new System.IO.StreamWriter(rfidscanDetailsPathString))
                            {
                                foreach (string line in lines__)
                                {
                                    file.WriteLine(line);
                                }
                            }
                            try
                            {
                                rfidScan1.rfImage.Image.Save(rfidscanFolderPathString.Replace("\"", "").Trim() + @"\RFIDImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);

                            }
                            catch (Exception ex) {
                                Console.WriteLine(ex.ToString());
                            }
                        }
                    }

                    just_hit_done = true;
                    this.Close();
                    //}
                    //DialogResult dResult_ = MessageBox.Show("Scan saved successfully",
                    //                                            "Success Report",
                    //                                            MessageBoxButtons.OK,
                    //                                            MessageBoxIcon.Information,
                    //                                            MessageBoxDefaultButton.Button1,
                    //                                            MessageBoxOptions.RightAlign,
                    //                                            false);
                    //if (dResult_ == DialogResult.OK)
                    //{
                    //    Clear();
                    //}

                    //if (dResult_ == DialogResult.OK)
                    //{
                    //    AddAdditionalScan addAdditionalScan = new AddAdditionalScan();
                    //    addAdditionalScan.ShowDialog();
                    //    if (addAdditionalScan.isDonePressed)
                    //    {
                    //        just_hit_done = true;
                    //        this.Close();
                    //    }
                    //}


                }

                else if (this.doc_type.Text.ToUpper().Equals("VISA"))
                {
                    string visaFolderPathString = System.IO.Path.Combine(docScanFolderPathString, "Visa_" + mrzScan1.doc_no.Text.Replace("*", "").ToString() + "_" + DateTime.Now.ToString("HH:mm:ss:f").Replace(":", "#")/**Visa_A04898745_11#11#11#1**/);
                    System.IO.Directory.CreateDirectory(visaFolderPathString);
                    string visaDetailsPathString = System.IO.Path.Combine(visaFolderPathString, "Visa Validation Details.travlr");
                    string[] vlines = {"***Visa Validation Details***",
                            "Passport Number = " + mrzScan1.doc_no.Text.ToString(),
                            "Passed = " + (PassportPassedVerified() && !isPostDated),
                            "Document No = " + mrzScan1.doc_no_flag.Text.ToString(),
                            "Date of birth = " + mrzScan1.dob_flag.Text.ToString(),
                            "Date of expiry = " + mrzScan1.doe_flag.Text.ToString(),
                            "Optional ID = " + mrzScan1.oid_flag.Text.ToString(),
                            "Valid Document = " + mrzScan1.vd_flag.Text.ToString(),
                            "Global CheckSum = " + mrzScan1.checks_flag.Text.ToString(),
                            "P Codeline Match = " + mrzScan1.cdm_flag.Text.ToString(),
                            "RFID availability = " + mrzScan1.rfid_flag.Text.ToString(),
                            "isFlagged = " + isPersonnelFlagged(mrzScan1.flagged_flag.Text.Trim().ToString()),
                            "Visa Start Date = " + (visaStartDate != DateTime.MinValue ? visaStartDate.ToString("dd MMM yyyy") : "UNKNOWN"),
                            "isPostDated = " + isPostDated
                    };
                    using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(visaDetailsPathString))
                    {
                        foreach (string line in vlines)
                        {
                            file.WriteLine(line);
                        }
                    }
                    string mrzscanFolderPathString = System.IO.Path.Combine(visaFolderPathString, "MRZ Scan");
                    System.IO.Directory.CreateDirectory(mrzscanFolderPathString);
                    string mrzscanCodelineDetailsPathString = System.IO.Path.Combine(mrzscanFolderPathString, "MRZ Codeline Details.travlr");
                    //if (!System.IO.File.Exists(mrzscanCodelineDetailsPathString))
                    //{
                    string[] vlines_ = {"***MRZ Codeline Details***",
                            "Document Number = " + mrzScan1.doc_no.Text.ToString(),
                            "Family Name = " + mrzScan1.family_name.Text.ToString(),
                            "Given Names = " + mrzScan1.given_names.Text.ToString(),
                            "Sex = " + mrzScan1.sex.Text.ToString(),
                            "Date of birth = " + mrzScan1.dob.Text.ToString(),
                            "Age = " + mrzScan1.age.Text.ToString(),
                            "Nationality = " + mrzScan1.nationality.Text.ToString(),
                            "Date of expiry = " + mrzScan1.doe.Text.ToString(),
                            "Issuer = " + mrzScan1.issuer.Text.ToString(),
                            "Codeline = " + mrzScan1.richTextBoxCodeline.Text.ToString(),
                            "Optional Data = " + mrzScan1.opt_data.Text.ToString(),
                            "Image Location = " + mrzscanFolderPathString + @"\View Images\MRZImage.jpeg"
                        };
                    using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(mrzscanCodelineDetailsPathString))
                    {
                        foreach (string line in vlines_)
                        {
                            file.WriteLine(line);
                        }
                    }
                    string viewImagesFolderPathString = System.IO.Path.Combine(mrzscanFolderPathString, "View Images");
                    System.IO.Directory.CreateDirectory(viewImagesFolderPathString);
                    try
                    {
                        mrzScan1.mrzImage.Image.Save(@"" + viewImagesFolderPathString.Trim().ToString() + @"\MRZImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(enabledRFID.ToString());
                    }

                    try
                    {
                        viewImages1.visImage.Image.Save(@"" + viewImagesFolderPathString.Trim().ToString() + @"\VISImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    try
                    {
                        viewImages1.irImage.Image.Save(@"" + viewImagesFolderPathString.Trim().ToString() + @"\IRImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    try
                    {
                        viewImages1.uvImage.Image.Save(@"" + viewImagesFolderPathString.Trim().ToString() + @"\UVImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    if (rfidScan1.codelineRichTextBox.TextLength > 1)
                    {
                        string rfidscanFolderPathString = System.IO.Path.Combine(visaFolderPathString, "RFID Scan");
                        System.IO.Directory.CreateDirectory(rfidscanFolderPathString);
                        string rfidscanDetailsPathString = System.IO.Path.Combine(rfidscanFolderPathString, "RFID Scan Details.travlr");
                        if (!System.IO.File.Exists(rfidscanDetailsPathString))
                        {
                            string[] lines__ = {"***RFID Scan Details***",
                            rfidScan1.chipID.Text.ToString(),
                            ">>>Data groups",
                            "READ SECTION",
                            "DG1 = " + RFIDDatagroupVerified(rfidScan1.dg1.BackColor),
                            "DG2 = " + RFIDDatagroupVerified(rfidScan1.dg2.BackColor),
                            "DG3 = " + RFIDDatagroupVerified(rfidScan1.dg3.BackColor),
                            "DG4 = " + RFIDDatagroupVerified(rfidScan1.dg4.BackColor),
                            "DG5 = " + RFIDDatagroupVerified(rfidScan1.dg5.BackColor),
                            "DG6 = " + RFIDDatagroupVerified(rfidScan1.dg6.BackColor),
                            "DG7 = " + RFIDDatagroupVerified(rfidScan1.dg7.BackColor),
                            "DG8 = " + RFIDDatagroupVerified(rfidScan1.dg8.BackColor),
                            "DG9 = " + RFIDDatagroupVerified(rfidScan1.dg9.BackColor),
                            "DG10 = " + RFIDDatagroupVerified(rfidScan1.dg10.BackColor),
                            "DG11 = " + RFIDDatagroupVerified(rfidScan1.dg11.BackColor),
                            "DG12 = " + RFIDDatagroupVerified(rfidScan1.dg12.BackColor),
                            "DG13 = " + RFIDDatagroupVerified(rfidScan1.dg13.BackColor),
                            "DG14 = " + RFIDDatagroupVerified(rfidScan1.dg14.BackColor),
                            "DG15 = " + RFIDDatagroupVerified(rfidScan1.dg15.BackColor),
                            "DG16 = " + RFIDDatagroupVerified(rfidScan1.dg16.BackColor),
                            "VALIDATED SECTION",
                            "DG1 = " + RFIDDatagroupVerified(rfidScan1.dg_1.BackColor),
                            "DG2 = " + RFIDDatagroupVerified(rfidScan1.dg_2.BackColor),
                            "DG3 = " + RFIDDatagroupVerified(rfidScan1.dg_3.BackColor),
                            "DG4 = " + RFIDDatagroupVerified(rfidScan1.dg_4.BackColor),
                            "DG5 = " + RFIDDatagroupVerified(rfidScan1.dg_5.BackColor),
                            "DG6 = " + RFIDDatagroupVerified(rfidScan1.dg_6.BackColor),
                            "DG7 = " + RFIDDatagroupVerified(rfidScan1.dg_7.BackColor),
                            "DG8 = " + RFIDDatagroupVerified(rfidScan1.dg_8.BackColor),
                            "DG9 = " + RFIDDatagroupVerified(rfidScan1.dg_9.BackColor),
                            "DG10 = " + RFIDDatagroupVerified(rfidScan1.dg_10.BackColor),
                            "DG11 = " + RFIDDatagroupVerified(rfidScan1.dg_11.BackColor),
                            "DG12 = " + RFIDDatagroupVerified(rfidScan1.dg_12.BackColor),
                            "DG13 = " + RFIDDatagroupVerified(rfidScan1.dg_13.BackColor),
                            "DG14 = " + RFIDDatagroupVerified(rfidScan1.dg_14.BackColor),
                            "DG15 = " + RFIDDatagroupVerified(rfidScan1.dg_15.BackColor),
                            "DG16 = " + RFIDDatagroupVerified(rfidScan1.dg_16.BackColor),
                            "\n",
                            ">>> ATTRIBUTES VALIDATION",
                            "Signed Attributes = " + signed_attrs,
                            "Passive Auth = " + passive_auth,
                            "Chip Auth = " + chip_auth,
                            "Signature = " + sign_,
                            "Active Auth = " + active_auth,
                            "Terminal Auth = " + term_auth,
                            "Doc Signer Cert = " + doc_signer_cert,
                            "\n",
                            "Codeline = " + rfidScan1.codelineRichTextBox.Text.ToString()
                        };
                            Console.WriteLine(rfidScan1.saImage.ImageLocation);
                            using (System.IO.StreamWriter file =
                                new System.IO.StreamWriter(rfidscanDetailsPathString))
                            {
                                foreach (string line in lines__)
                                {
                                    file.WriteLine(line);
                                }
                            }
                            try
                            {
                                rfidScan1.rfImage.Image.Save(rfidscanFolderPathString.Replace("\"", "").Trim() + @"\RFIDImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);

                            }
                            catch (Exception ex) {
                                Console.WriteLine(ex.ToString());
                            }
                        }
                    }
                    //}

                    just_hit_done = true;
                    this.Close();
                    //if (dResult_ == DialogResult.OK)
                    //{
                    //    AddAdditionalScan addAdditionalScan = new AddAdditionalScan();
                    //    addAdditionalScan.ShowDialog();
                    //    if (addAdditionalScan.isDonePressed)
                    //    {
                    //        just_hit_done = true;
                    //        this.Close();
                    //    }
                    //}
                }

                else
                {
                    string udocFolderPathString = System.IO.Path.Combine(docScanFolderPathString, doc_type.Text.ToString() + "_" + DateTime.Now.ToString("HH:mm:ss:f").Replace(":", "#")/**Ticket_DateTimeNow**/);
                    System.IO.Directory.CreateDirectory(udocFolderPathString);
                    string viewImagesFolderPathString = System.IO.Path.Combine(udocFolderPathString, "View Images");
                    System.IO.Directory.CreateDirectory(viewImagesFolderPathString);
                    Console.WriteLine("**********" + @"" + viewImagesFolderPathString.Trim().ToString());
                    try
                    {
                        mrzScan1.mrzImage.Image.Save(@"" + viewImagesFolderPathString.Trim().ToString() + @"\MRZImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(enabledRFID.ToString());
                    }

                    try
                    {
                        viewImages1.visImage.Image.Save(@"" + viewImagesFolderPathString.Trim().ToString() + @"\VISImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    try
                    {
                        viewImages1.irImage.Image.Save(@"" + viewImagesFolderPathString.Trim().ToString() + @"\IRImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    try
                    {
                        viewImages1.uvImage.Image.Save(@"" + viewImagesFolderPathString.Trim().ToString() + @"\UVImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    if (rfidScan1.codelineRichTextBox.TextLength > 1)
                    {
                        string rfidscanFolderPathString = System.IO.Path.Combine(udocFolderPathString, "RFID Scan");
                        System.IO.Directory.CreateDirectory(rfidscanFolderPathString);
                        string rfidscanDetailsPathString = System.IO.Path.Combine(rfidscanFolderPathString, "RFID Scan Details.travlr");
                        string[] lines__ = {"***RFID Scan Details***",
                            rfidScan1.chipID.Text.ToString(),
                            ">>>Data groups",
                            "READ SECTION",
                            "DG1 = " + RFIDDatagroupVerified(rfidScan1.dg1.BackColor),
                            "DG2 = " + RFIDDatagroupVerified(rfidScan1.dg2.BackColor),
                            "DG3 = " + RFIDDatagroupVerified(rfidScan1.dg3.BackColor),
                            "DG4 = " + RFIDDatagroupVerified(rfidScan1.dg4.BackColor),
                            "DG5 = " + RFIDDatagroupVerified(rfidScan1.dg5.BackColor),
                            "DG6 = " + RFIDDatagroupVerified(rfidScan1.dg6.BackColor),
                            "DG7 = " + RFIDDatagroupVerified(rfidScan1.dg7.BackColor),
                            "DG8 = " + RFIDDatagroupVerified(rfidScan1.dg8.BackColor),
                            "DG9 = " + RFIDDatagroupVerified(rfidScan1.dg9.BackColor),
                            "DG10 = " + RFIDDatagroupVerified(rfidScan1.dg10.BackColor),
                            "DG11 = " + RFIDDatagroupVerified(rfidScan1.dg11.BackColor),
                            "DG12 = " + RFIDDatagroupVerified(rfidScan1.dg12.BackColor),
                            "DG13 = " + RFIDDatagroupVerified(rfidScan1.dg13.BackColor),
                            "DG14 = " + RFIDDatagroupVerified(rfidScan1.dg14.BackColor),
                            "DG15 = " + RFIDDatagroupVerified(rfidScan1.dg15.BackColor),
                            "DG16 = " + RFIDDatagroupVerified(rfidScan1.dg16.BackColor),
                            "VALIDATED SECTION",
                            "DG1 = " + RFIDDatagroupVerified(rfidScan1.dg_1.BackColor),
                            "DG2 = " + RFIDDatagroupVerified(rfidScan1.dg_2.BackColor),
                            "DG3 = " + RFIDDatagroupVerified(rfidScan1.dg_3.BackColor),
                            "DG4 = " + RFIDDatagroupVerified(rfidScan1.dg_4.BackColor),
                            "DG5 = " + RFIDDatagroupVerified(rfidScan1.dg_5.BackColor),
                            "DG6 = " + RFIDDatagroupVerified(rfidScan1.dg_6.BackColor),
                            "DG7 = " + RFIDDatagroupVerified(rfidScan1.dg_7.BackColor),
                            "DG8 = " + RFIDDatagroupVerified(rfidScan1.dg_8.BackColor),
                            "DG9 = " + RFIDDatagroupVerified(rfidScan1.dg_9.BackColor),
                            "DG10 = " + RFIDDatagroupVerified(rfidScan1.dg_10.BackColor),
                            "DG11 = " + RFIDDatagroupVerified(rfidScan1.dg_11.BackColor),
                            "DG12 = " + RFIDDatagroupVerified(rfidScan1.dg_12.BackColor),
                            "DG13 = " + RFIDDatagroupVerified(rfidScan1.dg_13.BackColor),
                            "DG14 = " + RFIDDatagroupVerified(rfidScan1.dg_14.BackColor),
                            "DG15 = " + RFIDDatagroupVerified(rfidScan1.dg_15.BackColor),
                            "DG16 = " + RFIDDatagroupVerified(rfidScan1.dg_16.BackColor),
                            "\n",
                            ">>> ATTRIBUTES VALIDATION",
                            "Signed Attributes = " + signed_attrs,
                            "Passive Auth = " + passive_auth,
                            "Chip Auth = " + chip_auth,
                            "Signature = " + sign_,
                            "Active Auth = " + active_auth,
                            "Terminal Auth = " + term_auth,
                            "Doc Signer Cert = " + doc_signer_cert,
                            "\n",
                            "Codeline = " + rfidScan1.codelineRichTextBox.Text.ToString()
                        };
                        Console.WriteLine(rfidScan1.saImage.ImageLocation);
                        using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(rfidscanDetailsPathString))
                        {
                            foreach (string line in lines__)
                            {
                                file.WriteLine(line);
                            }
                        }
                        try
                        {
                            rfidScan1.rfImage.Image.Save(rfidscanFolderPathString.Replace("\"", "").Trim() + @"\RFIDImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        catch (Exception ex) {
                            Console.WriteLine(ex.ToString());
                        }
                    }

                    just_hit_done = true;
                    this.Close();

                    //if (dResult == DialogResult.OK)
                    //{
                    //    AddAdditionalScan addAdditionalScan = new AddAdditionalScan();
                    //    addAdditionalScan.ShowDialog();
                    //    if (addAdditionalScan.isDonePressed)
                    //    {
                    //        just_hit_done = true;
                    //        this.Close();
                    //    }
                    //}
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                DialogResult dResult = MessageBox.Show("Error saving scan",
                                                            "Error Report",
                                                            MessageBoxButtons.OK,
                                                            MessageBoxIcon.Error,
                                                            MessageBoxDefaultButton.Button1,
                                                            MessageBoxOptions.RightAlign,
                                                            false);
            }
        }

        private bool theresColorChange() {
            if (RFIDDatagroupVerified(rfidScan1.dg1.BackColor) || RFIDDatagroupVerified(rfidScan1.dg2.BackColor) || RFIDDatagroupVerified(rfidScan1.dg3.BackColor)
                || RFIDDatagroupVerified(rfidScan1.dg4.BackColor) || RFIDDatagroupVerified(rfidScan1.dg5.BackColor) || RFIDDatagroupVerified(rfidScan1.dg6.BackColor)
                || RFIDDatagroupVerified(rfidScan1.dg7.BackColor) || RFIDDatagroupVerified(rfidScan1.dg8.BackColor) || RFIDDatagroupVerified(rfidScan1.dg9.BackColor)
                || RFIDDatagroupVerified(rfidScan1.dg10.BackColor) || RFIDDatagroupVerified(rfidScan1.dg11.BackColor) || RFIDDatagroupVerified(rfidScan1.dg12.BackColor)
                || RFIDDatagroupVerified(rfidScan1.dg13.BackColor) || RFIDDatagroupVerified(rfidScan1.dg14.BackColor) || RFIDDatagroupVerified(rfidScan1.dg15.BackColor)
                || RFIDDatagroupVerified(rfidScan1.dg14.BackColor))
            {
                return true;
            }
            else {
                return false;
            }
        }
        


        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void flight_from_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddRecord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            };
        }
    }
}
