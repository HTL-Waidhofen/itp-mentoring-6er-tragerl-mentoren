﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
public class Benutzer
{
	public int ID { get; }
	public string Vorname { get; }
    public string Nachname { get; }
	public string Role { get; set; }
	public string Email { get; set; }
    public string Passwort { get; set; }
}


