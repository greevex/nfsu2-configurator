using System;
using System.Collections.Generic;
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
            0x006c9900, //VAUXHAUL CORSA 
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

        public static int[] fwd = new int[352] {
	        145, 194, 117, 60, 169, 198, 75, 62, 1, 0, 0, 62, 145, 194, 117, 61, 206, 204, 76, 61, 206, 204, 76, 61, 206, 204, 76, 61, 206, 204, 76, 61, 46, 212, 154, 60, 50, 8, 172, 60, 237, 81, 184, 60, 159, 239, 167, 60, 46, 212, 154, 60, 41, 160, 137, 60, 109, 9, 121, 60, 239, 13, 62, 60, 41, 160, 9, 60, 46, 212, 154, 60, 50, 8, 172, 60, 237, 81, 184, 60, 159, 239, 167, 60, 46, 212, 154, 60, 41, 160, 137, 60, 109, 9, 121, 60, 239, 13, 62, 60, 41, 160, 9, 60, 0, 0, 0, 0, 252, 237, 235, 58, 190, 116, 147, 59, 74, 80, 252, 59, 196, 100, 42, 60, 132, 226, 71, 60, 28, 47, 93, 60, 252, 237, 107, 60, 93, 177, 63, 60, 0, 0, 0, 0, 104, 102, 102, 63, 0, 0, 0, 0, 154, 153, 9, 64, 0, 0, 0, 0, 206, 204, 76, 63, 0, 0, 250, 67, 18, 54, 108, 64, 18, 54, 108, 64, 0, 0, 0, 0, 12, 215, 35, 61, 5, 0, 0, 0, 174, 71, 129, 64, 51, 51, 83, 192, 0, 0, 0, 0, 51, 51, 83, 64, 236, 81, 248, 63, 21, 174, 167, 63, 10, 215, 131, 63, 63, 10, 87, 63, 0, 0, 0, 0, 206, 204, 76, 63, 0, 0, 250, 67, 224, 190, 110, 64, 224, 190, 110, 64, 0, 0, 0, 0, 12, 215, 35, 61, 5, 0, 0, 0, 215, 163, 192, 64, 51, 51, 83, 192, 0, 0, 0, 0, 51, 51, 83, 64, 236, 81, 248, 63, 21, 174, 167, 63, 10, 215, 131, 63, 63, 10, 87, 63, 0, 0, 0, 0, 206, 204, 76, 63, 0, 0, 250, 67, 174, 71, 113, 64, 174, 71, 113, 64, 0, 0, 0, 0, 12, 215, 35, 61, 6, 0, 0, 0, 0, 0, 0, 65, 51, 51, 83, 192, 0, 0, 0, 0, 51, 51, 83, 64, 236, 81, 248, 63, 21, 174, 167, 63, 10, 215, 131, 63, 247, 40, 92, 63, 93, 143, 66, 63
        };
        public static int[] rwd = new int[352] {
	        145, 194, 117, 60, 87, 14, 77, 63, 1, 0, 0, 62, 206, 204, 76, 61, 206, 204, 76, 61, 206, 204, 76, 61, 206, 204, 76, 61, 206, 204, 76, 61, 51, 8, 44, 60, 164, 35, 57, 60, 167, 155, 68, 60, 28, 47, 93, 60, 145, 194, 117, 60, 222, 181, 132, 60, 109, 9, 121, 60, 25, 183, 81, 60, 164, 35, 57, 60, 51, 8, 44, 60, 164, 35, 57, 60, 167, 155, 68, 60, 28, 47, 93, 60, 145, 194, 117, 60, 222, 181, 132, 60, 109, 9, 121, 60, 25, 183, 81, 60, 164, 35, 57, 60, 0, 0, 0, 0, 0, 0, 0, 0, 83, 73, 29, 59, 112, 18, 131, 59, 25, 183, 209, 59, 83, 73, 29, 60, 167, 155, 68, 60, 252, 237, 107, 60, 25, 183, 81, 60, 0, 0, 0, 0, 104, 102, 102, 63, 0, 0, 0, 0, 102, 102, 6, 64, 0, 0, 0, 0, 206, 204, 76, 63, 0, 0, 250, 67, 59, 170, 128, 64, 59, 170, 128, 64, 0, 0, 128, 63, 12, 215, 35, 61, 5, 0, 0, 0, 174, 71, 129, 64, 74, 12, 106, 192, 0, 0, 0, 0, 68, 139, 84, 64, 189, 116, 243, 63, 140, 108, 167, 63, 0, 0, 128, 63, 155, 153, 89, 63, 0, 0, 0, 0, 206, 204, 76, 63, 0, 0, 250, 67, 8, 119, 125, 64, 8, 119, 125, 64, 0, 0, 128, 63, 12, 215, 35, 61, 5, 0, 0, 0, 215, 163, 192, 64, 74, 12, 106, 192, 0, 0, 0, 0, 68, 139, 84, 64, 189, 116, 243, 63, 140, 108, 167, 63, 0, 0, 128, 63, 186, 30, 69, 63, 0, 0, 0, 0, 206, 204, 76, 63, 0, 0, 250, 67, 154, 153, 121, 64, 154, 153, 121, 64, 0, 0, 128, 63, 12, 215, 35, 61, 6, 0, 0, 0, 0, 0, 0, 65, 74, 12, 106, 192, 0, 0, 0, 0, 68, 139, 84, 64, 189, 116, 243, 63, 140, 108, 167, 63, 31, 133, 139, 63, 32, 133, 107, 63, 186, 30, 69, 63
        };
        public static int[] allwd = new int[352] {
	        145, 194, 117, 60, 155, 153, 25, 63, 1, 0, 0, 62, 206, 204, 76, 61, 206, 204, 76, 61, 206, 204, 76, 61, 206, 204, 76, 61, 206, 204, 76, 61, 60, 112, 78, 60, 70, 216, 112, 60, 46, 212, 154, 60, 195, 168, 164, 60, 10, 27, 158, 60, 81, 141, 151, 60, 225, 45, 144, 60, 41, 160, 137, 60, 70, 216, 112, 60, 60, 112, 78, 60, 70, 216, 112, 60, 46, 212, 154, 60, 195, 168, 164, 60, 10, 27, 158, 60, 81, 141, 151, 60, 225, 45, 144, 60, 41, 160, 137, 60, 70, 216, 112, 60, 0, 0, 0, 0, 167, 155, 196, 59, 125, 242, 48, 60, 252, 237, 107, 60, 252, 237, 107, 60, 252, 237, 107, 60, 252, 237, 107, 60, 252, 237, 107, 60, 252, 237, 107, 60, 0, 0, 0, 0, 206, 204, 76, 63, 206, 204, 76, 61, 51, 51, 3, 64, 0, 0, 0, 0, 206, 204, 76, 63, 0, 0, 250, 67, 81, 107, 114, 64, 81, 107, 114, 64, 1, 0, 0, 63, 12, 215, 35, 61, 4, 0, 0, 0, 174, 71, 129, 64, 164, 112, 45, 192, 0, 0, 0, 0, 164, 112, 45, 64, 11, 215, 195, 63, 0, 0, 128, 63, 145, 194, 53, 63, 0, 0, 0, 0, 0, 0, 0, 0, 206, 204, 76, 63, 0, 0, 250, 67, 118, 2, 118, 64, 118, 2, 118, 64, 1, 0, 0, 63, 12, 215, 35, 61, 4, 0, 0, 0, 215, 163, 192, 64, 164, 112, 45, 192, 0, 0, 0, 0, 164, 112, 45, 64, 11, 215, 195, 63, 0, 0, 128, 63, 145, 194, 53, 63, 0, 0, 0, 0, 0, 0, 0, 0, 206, 204, 76, 63, 0, 0, 250, 67, 154, 153, 121, 64, 154, 153, 121, 64, 1, 0, 0, 63, 12, 215, 35, 61, 5, 0, 0, 0, 0, 0, 0, 65, 51, 51, 83, 192, 0, 0, 0, 0, 51, 51, 83, 64, 206, 204, 204, 63, 205, 204, 140, 63, 134, 235, 81, 63, 32, 133, 43, 63, 0, 0, 0, 0
        };
    }
}
