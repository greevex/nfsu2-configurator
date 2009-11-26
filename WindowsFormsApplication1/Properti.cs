﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFSU2CH
{
    class Properti
    {
        public static int[] CARS = new int[46]
        {
            0x006c5d10, //PEUGOT
            0x006c65a0, //FORD FOCUS
            0x006c6e30, //TOYOTA COROLLA
            0x006c76c0, //NISSAN 240SX
            0x006c7f50, //MAZDA MIATA
            0x006c87e0, //HONDA CIVIC
            0x006c9070, //PEGOUT 106
            0x006c9900, //CORSA (помоему корса это тойота, только там хуйня какая то написана)
            0x006ca190, //HUMMER
            0x006caa20, //LINCOLN NAVIGATOR
            0x006cb2b0, //CADILLAC ESCALADE
            0x006cbb40, //HYUNDAI TIBURON
            0x006cc3d0, //NISSAN SENTRA
            0x006ccc60, //TOYOTA CELICA
            0x006cd4f0, //LEXUS IS300
            0x006cdd80, //TOYOTA SUPRA
            0x006ce610, //VOLKSWAGEN GOLF
            0x006ceea0, //AUDI A3
            0x006cf730, //ACURA RSX
            0x006cffc0, //MITSUBISHI ECLIPSE
            0x006d0850, //AUDI TT
            0x006d10e0, //MAZDA RX8
            0x006d1970, //NISSAN 350Z
            0x006d2200, //INFINITI G35
            0x006d2a90, //MITSUBISHI 3000GT
            0x006d3320, //PONTIAC GTO
            0x006d3bb0, //FORD MUSTANG GT
            0x006d4440, //NISSAN SKYLINE
            0x006d4cd0, //MITSUBISHI LANCER EVO8
            0x006d5560, //MAZDA RX7
            0x006d5df0, //SUBARU IMPREZA WRX
            0x006d6680, //GENERIC TAXI
            0x006d6f10, //GENERIC SEDAN 4DR
            0x006d77a0, //GENERIC AMBULANCE
            0x006d8030, //GENERIC TAXI 02
            0x006d88c0, //GENERIC PANELVAN
            0x006d9150, //GENERIC COUPE
            0x006d99e0, //GENERIC FIRETRUCK
            0x006da270, //GROLSON PARCELVAN
            0x006dab00, //Chevrolet pickup 
            0x006db390, //Chevrolet 4dr sedan
            0x006dbc20, //silver eagle bus
            0x006dc4b0, //GENERIC SUV
            0x006dcd40, //GENERIC MINIVAN
            0x006dd5d0, //GENERIC HATCHBACK
            0x006dde60, //GENERIC HATCHBACK 02
        };
        public static int getPosition(string carName)
        {
            switch (carName)
            {
                case "PEUGOT":
                    return Properti.CARS[0];
                case "FORD FOCUS":
                    return Properti.CARS[1];
                case "TOYOTA COROLLA":
                    return Properti.CARS[2];
                case "NISSAN 240SX":
                    return Properti.CARS[3];
                case "MAZDA MIATA":
                    return Properti.CARS[4];
                case "HONDA CIVIC":
                    return Properti.CARS[5];
                case "PEGOUT 106":
                    return Properti.CARS[6];
                case "CORSA":
                    return Properti.CARS[7];
                case "HUMMER":
                    return Properti.CARS[8];
                case "LINCOLN NAVIGATOR":
                    return Properti.CARS[9];
                case "CADILLAC ESCALADE":
                    return Properti.CARS[10];
                case "HYUNDAI TIBURON":
                    return Properti.CARS[11];
                case "NISSAN SENTRA":
                    return Properti.CARS[12];
                case "TOYOTA CELICA":
                    return Properti.CARS[13];
                case "LEXUS IS300":
                    return Properti.CARS[14];
                case "TOYOTA SUPRA":
                    return Properti.CARS[15];
                case "VOLKSWAGEN GOLF":
                    return Properti.CARS[16];
                case "AUDI A3":
                    return Properti.CARS[17];
                case "ACURA RSX":
                    return Properti.CARS[18];
                case "MITSUBISHI ECLIPSE":
                    return Properti.CARS[19];
                case "AUDI TT":
                    return Properti.CARS[20];
                case "MAZDA RX8":
                    return Properti.CARS[21];
                case "NISSAN 350Z":
                    return Properti.CARS[22];
                case "INFINITI G35":
                    return Properti.CARS[23];
                case "MITSUBISHI 3000GT":
                    return Properti.CARS[24];
                case "PONTIAC GTO":
                    return Properti.CARS[25];
                case "FORD MUSTANG GT":
                    return Properti.CARS[26];
                case "NISSAN SKYLINE":
                    return Properti.CARS[27];
                case "MITSUBISHI LANCER EVO8":
                    return Properti.CARS[28];
                case "MAZDA RX7":
                    return Properti.CARS[29];
                case "SUBARU IMPREZA WRX":
                    return Properti.CARS[30];
                default:
                    return 0;
            }
        }
    }
}