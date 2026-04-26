namespace TravelPass
{
    partial class CreateNewFlight
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flight_date = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.flight_airline = new System.Windows.Forms.TextBox();
            this.flight_from = new System.Windows.Forms.TextBox();
            this.country_from = new System.Windows.Forms.TextBox();
            this.flight_depart_time = new System.Windows.Forms.TextBox();
            this.flight_depart_term = new System.Windows.Forms.TextBox();
            this.flight_to = new System.Windows.Forms.TextBox();
            this.country_to = new System.Windows.Forms.TextBox();
            this.flight_arrive_time = new System.Windows.Forms.TextBox();
            this.flight_arrive_term = new System.Windows.Forms.TextBox();
            this.flight_type = new System.Windows.Forms.TextBox();
            this.flight_length = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_cancel_flight = new System.Windows.Forms.Button();
            this.btn_create_flight = new System.Windows.Forms.Button();
            this.flight_number = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.flight_class_combo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // flight_date
            // 
            this.flight_date.Location = new System.Drawing.Point(196, 62);
            this.flight_date.Margin = new System.Windows.Forms.Padding(4);
            this.flight_date.Name = "flight_date";
            this.flight_date.Size = new System.Drawing.Size(347, 22);
            this.flight_date.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Flight Details";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(279, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(267, 2);
            this.label3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(72, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 2);
            this.label1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(121, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Date";
            // 
            // flight_airline
            // 
            this.flight_airline.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.flight_airline.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.flight_airline.ForeColor = System.Drawing.SystemColors.WindowText;
            this.flight_airline.Location = new System.Drawing.Point(196, 202);
            this.flight_airline.Margin = new System.Windows.Forms.Padding(4);
            this.flight_airline.Name = "flight_airline";
            this.flight_airline.ReadOnly = true;
            this.flight_airline.Size = new System.Drawing.Size(347, 22);
            this.flight_airline.TabIndex = 2;
            // 
            // flight_from
            // 
            this.flight_from.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.flight_from.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.flight_from.Location = new System.Drawing.Point(196, 245);
            this.flight_from.Margin = new System.Windows.Forms.Padding(4);
            this.flight_from.Name = "flight_from";
            this.flight_from.ReadOnly = true;
            this.flight_from.Size = new System.Drawing.Size(347, 22);
            this.flight_from.TabIndex = 2;
            this.flight_from.TextChanged += new System.EventHandler(this.flight_from_TextChanged);
            this.flight_from.Leave += new System.EventHandler(this.flight_from_Leave);
            // 
            // country_from
            // 
            this.country_from.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.country_from.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.country_from.Location = new System.Drawing.Point(196, 288);
            this.country_from.Margin = new System.Windows.Forms.Padding(4);
            this.country_from.Name = "country_from";
            this.country_from.ReadOnly = true;
            this.country_from.Size = new System.Drawing.Size(347, 22);
            this.country_from.TabIndex = 2;
            // 
            // flight_depart_time
            // 
            this.flight_depart_time.Location = new System.Drawing.Point(196, 335);
            this.flight_depart_time.Margin = new System.Windows.Forms.Padding(4);
            this.flight_depart_time.Name = "flight_depart_time";
            this.flight_depart_time.ReadOnly = true;
            this.flight_depart_time.Size = new System.Drawing.Size(347, 22);
            this.flight_depart_time.TabIndex = 2;
            // 
            // flight_depart_term
            // 
            this.flight_depart_term.Location = new System.Drawing.Point(196, 383);
            this.flight_depart_term.Margin = new System.Windows.Forms.Padding(4);
            this.flight_depart_term.Name = "flight_depart_term";
            this.flight_depart_term.ReadOnly = true;
            this.flight_depart_term.Size = new System.Drawing.Size(347, 22);
            this.flight_depart_term.TabIndex = 2;
            // 
            // flight_to
            // 
            this.flight_to.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.flight_to.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.flight_to.Location = new System.Drawing.Point(196, 427);
            this.flight_to.Margin = new System.Windows.Forms.Padding(4);
            this.flight_to.Name = "flight_to";
            this.flight_to.ReadOnly = true;
            this.flight_to.Size = new System.Drawing.Size(347, 22);
            this.flight_to.TabIndex = 2;
            this.flight_to.Leave += new System.EventHandler(this.flight_to_Leave);
            // 
            // country_to
            // 
            this.country_to.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.country_to.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.country_to.Location = new System.Drawing.Point(196, 473);
            this.country_to.Margin = new System.Windows.Forms.Padding(4);
            this.country_to.Name = "country_to";
            this.country_to.ReadOnly = true;
            this.country_to.Size = new System.Drawing.Size(347, 22);
            this.country_to.TabIndex = 2;
            // 
            // flight_arrive_time
            // 
            this.flight_arrive_time.Location = new System.Drawing.Point(196, 524);
            this.flight_arrive_time.Margin = new System.Windows.Forms.Padding(4);
            this.flight_arrive_time.Name = "flight_arrive_time";
            this.flight_arrive_time.Size = new System.Drawing.Size(347, 22);
            this.flight_arrive_time.TabIndex = 2;
            // 
            // flight_arrive_term
            // 
            this.flight_arrive_term.Location = new System.Drawing.Point(196, 570);
            this.flight_arrive_term.Margin = new System.Windows.Forms.Padding(4);
            this.flight_arrive_term.Name = "flight_arrive_term";
            this.flight_arrive_term.Size = new System.Drawing.Size(347, 22);
            this.flight_arrive_term.TabIndex = 2;
            // 
            // flight_type
            // 
            this.flight_type.AutoCompleteCustomSource.AddRange(new string[] {
            "Aerospatiale (Sud Aviation) Se.210 Caravelle",
            "Aerospatiale/Alenia ATR 42-300",
            "Aerospatiale/Alenia ATR 42-500",
            "Aerospatiale/Alenia ATR 42-600",
            "Aerospatiale/Alenia ATR 72",
            "Airbus A300",
            "Airbus A300-600",
            "Airbus A310",
            "Airbus A318",
            "Airbus A319",
            "Airbus A320",
            "Airbus A321",
            "Airbus A330",
            "Airbus A330-200",
            "Airbus A330-300",
            "Airbus A340",
            "Airbus A340-200",
            "Airbus A340-300",
            "Airbus A340-500",
            "Airbus A340-600",
            "Airbus A350",
            "Airbus A350-1000",
            "Airbus A350-900",
            "Airbus A380",
            "Airbus A380-800",
            "Antonov An-148",
            "Antonov An-158",
            "Antonov AN-72",
            "Avro RJ100",
            "Avro RJ70",
            "Avro RJ85",
            "BAe 146",
            "BAe 146-100",
            "BAe 146-200",
            "BAe 146-300",
            "Beechcraft 1900",
            "Beechcraft Baron",
            "Bell 212",
            "Boeing 707",
            "Boeing 717",
            "Boeing 720B",
            "Boeing 727",
            "Boeing 727-100",
            "Boeing 727-200",
            "Boeing 737",
            "Boeing 737 MAX 8",
            "Boeing 737-200",
            "Boeing 737-300",
            "Boeing 737-400",
            "Boeing 737-500",
            "Boeing 737-600",
            "Boeing 737-700",
            "Boeing 737-800",
            "Boeing 737-900",
            "Boeing 747",
            "Boeing 747-100",
            "Boeing 747-200",
            "Boeing 747-300",
            "Boeing 747-400",
            "Boeing 747-8",
            "Boeing 747SP",
            "Boeing 747SR",
            "Boeing 757",
            "Boeing 757-200",
            "Boeing 757-300",
            "Boeing 767",
            "Boeing 767-200",
            "Boeing 767-300",
            "Boeing 767-400",
            "Boeing 777",
            "Boeing 777-200",
            "Boeing 777-200LR",
            "Boeing 777-300",
            "Boeing 777-300ER",
            "Boeing 787",
            "Boeing 787-10",
            "Boeing 787-8",
            "Boeing 787-9",
            "Bombardier CS100",
            "Bombardier CS300",
            "Bombardier Global Express",
            "British Aerospace ATP",
            "British Aerospace Jetstream 31",
            "British Aerospace Jetstream 32",
            "British Aerospace Jetstream 41",
            "Canadair CL-44",
            "Canadair Regional Jet 100",
            "Canadair Regional Jet 1000",
            "Canadair Regional Jet 200",
            "Canadair Regional Jet 700",
            "Canadair Regional Jet 900",
            "Cessna 172",
            "Cessna 182 Skylane",
            "Cessna 208 Caravan",
            "Cessna 210 Centurion",
            "Cessna Citation CJ3",
            "Cessna Citation CJ4",
            "Cessna Citation Excel",
            "Cessna Citation I",
            "Cessna Citation II",
            "Cessna Citation Mustang",
            "Cessna Citation Sovereign",
            "Cessna Citation X",
            "COMAC C-919",
            "Concorde",
            "Dassault Falcon 2000",
            "Dassault Falcon 7X",
            "De Havilland Canada DHC-4 Caribou",
            "De Havilland Canada DHC-6 Twin Otter",
            "De Havilland Canada DHC-7 Dash 7",
            "De Havilland Canada DHC-8-300 Dash 8",
            "De Havilland Canada DHC-8-400 Dash 8Q",
            "Douglas DC-10",
            "Douglas DC-3",
            "Douglas DC-6",
            "Douglas DC-9-10",
            "Douglas DC-9-30",
            "Douglas DC-9-40",
            "Douglas DC-9-50",
            "Embraer 170",
            "Embraer 190",
            "Embraer 195",
            "Embraer EMB 110 Bandeirante",
            "Embraer EMB 120 Brasilia",
            "Embraer Legacy 600",
            "Embraer Phenom 100",
            "Embraer Phenom 300",
            "Embraer RJ135",
            "Embraer RJ140",
            "Embraer RJ145",
            "Fairchild Dornier 328JET",
            "Fairchild Dornier Do.228",
            "Fairchild Dornier Do.328",
            "Fokker 100",
            "Fokker 50",
            "Fokker 70",
            "Fokker F27 Friendship",
            "Gulfstream IV",
            "Gulfstream V",
            "Harbin Yunshuji Y12",
            "Hawker Siddeley HS 748",
            "Ilyushin IL18",
            "Ilyushin IL62",
            "Ilyushin IL76",
            "Ilyushin IL86",
            "Ilyushin IL96",
            "Learjet 35",
            "Learjet 60",
            "Lockheed L-188 Electra",
            "McDonnell Douglas MD-11",
            "McDonnell Douglas MD-81",
            "McDonnell Douglas MD-82",
            "McDonnell Douglas MD-83",
            "McDonnell Douglas MD-87",
            "McDonnell Douglas MD-88",
            "McDonnell Douglas MD-90",
            "NAMC YS-11",
            "Partenavia P.68",
            "Pilatus Britten-Norman BN-2A Mk III Trislander",
            "Pilatus Britten-Norman BN-2A/B Islander",
            "Pilatus PC-12",
            "Pilatus PC-6 Turbo Porter",
            "Piper PA-31 Navajo",
            "Saab 2000",
            "Saab SF340A/B",
            "Shorts SD.360",
            "Sikorsky S-61",
            "Sikorsky S-76",
            "Sukhoi Superjet 100-95",
            "Tupolev Tu-134",
            "Tupolev Tu-144",
            "Tupolev Tu-154",
            "Tupolev Tu-204",
            "Yakovlev Yak-40",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""});
            this.flight_type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.flight_type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.flight_type.Location = new System.Drawing.Point(196, 618);
            this.flight_type.Margin = new System.Windows.Forms.Padding(4);
            this.flight_type.Name = "flight_type";
            this.flight_type.Size = new System.Drawing.Size(347, 22);
            this.flight_type.TabIndex = 2;
            // 
            // flight_length
            // 
            this.flight_length.Location = new System.Drawing.Point(196, 668);
            this.flight_length.Margin = new System.Windows.Forms.Padding(4);
            this.flight_length.Name = "flight_length";
            this.flight_length.Size = new System.Drawing.Size(347, 22);
            this.flight_length.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(111, 203);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Airline";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(52, 156);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 18);
            this.label6.TabIndex = 3;
            this.label6.Text = "Flight Number";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(117, 246);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 18);
            this.label7.TabIndex = 3;
            this.label7.Text = "From";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(59, 289);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 18);
            this.label16.TabIndex = 3;
            this.label16.Text = "Country From";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(43, 336);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 18);
            this.label8.TabIndex = 3;
            this.label8.Text = "Departure Time";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 384);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 18);
            this.label9.TabIndex = 3;
            this.label9.Text = "Departure Terminal";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(139, 428);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 18);
            this.label10.TabIndex = 3;
            this.label10.Text = "To";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(80, 474);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 18);
            this.label15.TabIndex = 3;
            this.label15.Text = "Country To";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(72, 526);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 18);
            this.label11.TabIndex = 3;
            this.label11.Text = "Arrival Time";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(44, 571);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 18);
            this.label12.TabIndex = 3;
            this.label12.Text = "Arrival Terminal";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(69, 619);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 18);
            this.label13.TabIndex = 3;
            this.label13.Text = "Aircraft Type";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(5, 668);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(146, 18);
            this.label14.TabIndex = 3;
            this.label14.Text = "Length of Flight (Hrs)";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // btn_cancel_flight
            // 
            this.btn_cancel_flight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_cancel_flight.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel_flight.ForeColor = System.Drawing.Color.White;
            this.btn_cancel_flight.Location = new System.Drawing.Point(159, 716);
            this.btn_cancel_flight.Margin = new System.Windows.Forms.Padding(4);
            this.btn_cancel_flight.Name = "btn_cancel_flight";
            this.btn_cancel_flight.Size = new System.Drawing.Size(165, 34);
            this.btn_cancel_flight.TabIndex = 21;
            this.btn_cancel_flight.Text = "Cancel";
            this.btn_cancel_flight.UseVisualStyleBackColor = false;
            this.btn_cancel_flight.Click += new System.EventHandler(this.back_Click);
            // 
            // btn_create_flight
            // 
            this.btn_create_flight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(138)))), ((int)(((byte)(214)))));
            this.btn_create_flight.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_create_flight.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_create_flight.Location = new System.Drawing.Point(361, 716);
            this.btn_create_flight.Margin = new System.Windows.Forms.Padding(4);
            this.btn_create_flight.Name = "btn_create_flight";
            this.btn_create_flight.Size = new System.Drawing.Size(183, 34);
            this.btn_create_flight.TabIndex = 22;
            this.btn_create_flight.Text = "Create";
            this.btn_create_flight.UseVisualStyleBackColor = false;
            this.btn_create_flight.Click += new System.EventHandler(this.btn_create_flight_Click);
            // 
            // flight_number
            // 
            this.flight_number.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.flight_number.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.flight_number.FormattingEnabled = true;
            this.flight_number.Location = new System.Drawing.Point(196, 155);
            this.flight_number.Margin = new System.Windows.Forms.Padding(4);
            this.flight_number.Name = "flight_number";
            this.flight_number.Size = new System.Drawing.Size(348, 24);
            this.flight_number.TabIndex = 23;
            this.flight_number.SelectedIndexChanged += new System.EventHandler(this.flight_number_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(52, 107);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 18);
            this.label17.TabIndex = 3;
            this.label17.Text = "Flight Class";
            // 
            // flight_class_combo
            // 
            this.flight_class_combo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.flight_class_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.flight_class_combo.FormattingEnabled = true;
            this.flight_class_combo.Items.AddRange(new object[] {
            "Upper",
            "Premium Economy",
            "Economy"});
            this.flight_class_combo.Location = new System.Drawing.Point(196, 106);
            this.flight_class_combo.Margin = new System.Windows.Forms.Padding(4);
            this.flight_class_combo.Name = "flight_class_combo";
            this.flight_class_combo.Size = new System.Drawing.Size(348, 24);
            this.flight_class_combo.TabIndex = 23;
            // 
            // CreateNewFlight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(559, 758);
            this.Controls.Add(this.flight_class_combo);
            this.Controls.Add(this.flight_number);
            this.Controls.Add(this.btn_create_flight);
            this.Controls.Add(this.btn_cancel_flight);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.flight_length);
            this.Controls.Add(this.flight_type);
            this.Controls.Add(this.flight_arrive_term);
            this.Controls.Add(this.flight_arrive_time);
            this.Controls.Add(this.country_to);
            this.Controls.Add(this.flight_to);
            this.Controls.Add(this.flight_depart_term);
            this.Controls.Add(this.flight_depart_time);
            this.Controls.Add(this.country_from);
            this.Controls.Add(this.flight_from);
            this.Controls.Add(this.flight_airline);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flight_date);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateNewFlight";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create New Flight";
            this.Load += new System.EventHandler(this.CreateNewFlight_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CreateNewFlight_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker flight_date;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox flight_airline;
        private System.Windows.Forms.TextBox flight_from;
        private System.Windows.Forms.TextBox country_from;
        private System.Windows.Forms.TextBox flight_depart_time;
        private System.Windows.Forms.TextBox flight_depart_term;
        private System.Windows.Forms.TextBox flight_to;
        private System.Windows.Forms.TextBox country_to;
        private System.Windows.Forms.TextBox flight_arrive_time;
        private System.Windows.Forms.TextBox flight_arrive_term;
        private System.Windows.Forms.TextBox flight_type;
        private System.Windows.Forms.TextBox flight_length;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btn_cancel_flight;
        private System.Windows.Forms.Button btn_create_flight;
        private System.Windows.Forms.ComboBox flight_number;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox flight_class_combo;
    }
}