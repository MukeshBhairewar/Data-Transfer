using System;

namespace Datatransfer
{
    /// <summary>
    /// Class For Convert Data Into Byte And Calculate Day,Hour,Minute,Seconds
    /// </summary> 
    internal class DataTransfer
    {
        /// <summary>
        /// Main method display day,hour,minute,second for file transfer
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            int choice = 1;
            Console.WriteLine($"{Environment.NewLine}================================Data Transfer Application================================================");

            while (choice != 5)
            {
                // Display Contain For File Format option
                Console.WriteLine($"{Environment.NewLine}=================If You Want Perform Operation choose Any File Format==================================={Environment.NewLine}");
                Console.WriteLine(" 1. KB");
                Console.WriteLine(" 2. MB");
                Console.WriteLine(" 3. GB");
                Console.WriteLine(" 4. TB");
                Console.WriteLine(" 5. Exit");
                Console.WriteLine("========================================================================================================");
                // User choice input
                Console.Write(" Select Your File Size format :-  ");
                string input = Console.ReadLine();
                bool IsSucess = int.TryParse(input, out choice);

                // For User choice Validation
                if (IsSucess == false)
                {
                    Console.WriteLine($"{Environment.NewLine}String Format Is invalid for this operation");
                    continue;
                }
                if (choice <= 0)
                {
                    Console.WriteLine($"{Environment.NewLine}Negative value or 0 are invalid inputs");
                    continue;
                }

                switch (choice)
                {
                    case (int)Enum.UserFormatChoice.KiloByte:
                        // Method to show kilobyte calculation
                        TakeFileFormatAndConvertIntoByte(ConstantVariables.OneKiloByteIntoByte);
                        break;
                    case (int)Enum.UserFormatChoice.MegaByte:
                        // Method to show megabyte calculation
                        TakeFileFormatAndConvertIntoByte(ConstantVariables.OneMegaByteIntoByte);
                        break;
                    case (int)Enum.UserFormatChoice.GigaByte:
                        // Method to show gigabyte calculation
                        TakeFileFormatAndConvertIntoByte(ConstantVariables.OneGigaByteIntoByte);
                        break;
                    case (int)Enum.UserFormatChoice.TeraByte:
                        // Method to show terabyte calculation
                        TakeFileFormatAndConvertIntoByte(ConstantVariables.OneTeraByteIntoByte);
                        break;
                    case (int)Enum.UserFormatChoice.Exit:
                        // If user Enter Exit Input case 4 excute
                        Console.WriteLine(Environment.NewLine + "The program is Exit Thank You!!");
                        break;
                    default:
                        // If user  invalid choice default message display
                        Console.WriteLine(Environment.NewLine + "Enter file format is invalid");
                        break;
                }
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Take byte file size and show transfer time
        /// </summary>
        /// <param name="fileSize"> Converted file size in byte</param>
        private static void CalculateAndDisplayTransferTime(double fileSize)
        {
            TimeCalculation timecalculation = new TimeCalculation();
            double totalSecond = timecalculation.CalculateTotalSeconds(fileSize);
            double day = timecalculation.CalculateDay(totalSecond);
            double hour = timecalculation.CalculateHour(totalSecond);
            double minute = timecalculation.CalculateMinute(totalSecond);
            double second = timecalculation.CalculateSeconds(totalSecond);
            Console.WriteLine($"{Environment.NewLine}Output:-");
            Console.WriteLine("-------");
            Console.WriteLine($"{Environment.NewLine}To Transfer Byte {fileSize} Data Below Time Is Required:-");
            double convertedDay = Math.Floor(day);

            // For show value greater than 0
            if (convertedDay > 0)
            {
                Console.WriteLine($"{Environment.NewLine}Day:-" + (convertedDay));
            }

            // Math.Floor Use for remove decimal percision
            double convertedHour = Math.Floor(hour);

            // For show value greater than 0
            if (convertedHour > 0)
            {
                Console.WriteLine($"{Environment.NewLine}Hour:-" + (convertedHour));
            }

            // Math.Floor Use for remove decimal percision
            double convertedMinute = Math.Floor(minute);

            // For show value greater than 0
            if (convertedMinute > 0)
            {
                Console.WriteLine($"{Environment.NewLine}Minute:-" + (convertedMinute));
            }

            // For show value greater than 0
            if (second > 0)
            {
                Console.WriteLine(Environment.NewLine + "Seconds: " + Math.Ceiling(second));
            }

            Console.WriteLine($"{Environment.NewLine}<><><><><><><><><><><><><><><><><><><><><><><>Thank You!!<<><><><><><><><><><>><><><><><><><><><><><>{ Environment.NewLine}");
        }

        /// <summary>
        /// Method For Error Occur
        /// </summary>
        /// <param name="IsSucess"></param>
        /// <returns> User file size and out in Issucess </returns>
        private static double TakeUserFileSizeAndValidate(out bool IsSucess)
        {
            IsSucess = false;
            double fileSize = 0;

            try
            {
                string input = Console.ReadLine();
                IsSucess = double.TryParse(input, out fileSize);

                //  Validate the filesize 
                if (IsSucess != true)
                {
                    Console.WriteLine($"{Environment.NewLine}String Format Is invalid for this operation");
                    return fileSize;
                }
                if (fileSize <= 0)
                {
                    Console.WriteLine($"{Environment.NewLine}Negative value or 0 are invalid inputs");
                }
            }

            catch (Exception ex) when (ex is FormatException || ex is OverflowException)
            {
                Console.WriteLine($"{Environment.NewLine}String Format Is invalid for this operation");
            }

            return fileSize;
        }

        /// <summary>
        /// Method for converting data into byte
        /// </summary>
        /// <param name="formatconvertervalues"> Pass File format size</param>
        private static void TakeFileFormatAndConvertIntoByte(double formatConverterValues)
        {
            Console.WriteLine("Input:-");
            Console.WriteLine("-------");
            Console.Write("Enter The Filesize :-");
            double userFilesize = 0;
            bool IsSucess = false;
            // User input for file size
            userFilesize = TakeUserFileSizeAndValidate(out IsSucess);

            // If blocks for validation and display message
            if (IsSucess != true)
            {
                return;
            }
            if (userFilesize <= 0)
            {
                return;
            }

            // Convert User file size into Byte
            double fileSizeInByte = userFilesize * formatConverterValues;
            CalculateAndDisplayTransferTime(fileSizeInByte);
        }
    }
}
