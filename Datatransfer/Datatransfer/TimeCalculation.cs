namespace Datatransfer
{
    /// <summary>
    /// Claculation class for calculate day minute hour second for transfer data
    /// </summary>
    public class TimeCalculation
    {
        /// <summary>
        /// Method for calculate day
        /// </summary>
        /// <param name="seconds">Total seconds</param>
        /// <returns>Day</returns>
        public double CalculateDay(double seconds)
        {
            bool IsSucess = MethodForParameterValidation(seconds);

            // Validate method input
            if (IsSucess != true)
            {
                System.Console.WriteLine("Negative value or 0 are invalid inputs");
                return seconds;
            }

            // Calculate whole day
            double day = seconds / ConstantVariables.OneDayInSeconds;
            return day;
        }

        /// <summary>
        /// Method for calculate hour
        /// </summary>
        /// <param name="seconds">Total Seconds</param>
        /// <returns>Hour</returns>
        public double CalculateHour(double seconds)
        {
            bool IsSucess = MethodForParameterValidation(seconds);

            // Validate method input
            if (IsSucess != true)
            {
                System.Console.WriteLine("Negative value or 0 are invalid inputs");
                return seconds;
            }

            // Calculate remainder after whole days are consumed
            seconds = seconds % ConstantVariables.OneDayInSeconds;
            // Calculate whole hours
            double hour = seconds / ConstantVariables.OneHourInSeconds;
            return hour;
        }

        /// <summary>
        /// Method for calculate minute
        /// </summary>
        /// <param name="seconds">Total seconds</param>
        /// <returns>Minute</returns>
        public double CalculateMinute(double seconds)
        {
            bool IsSucess = MethodForParameterValidation(seconds);

            // Validate method input
            if (IsSucess != true)
            {
                System.Console.WriteLine("Negative value or 0 are invalid inputs");
                return seconds;
            }

            // Calculate remainder after whole hour are consumed
            seconds = seconds % ConstantVariables.OneHourInSeconds;
            // Calculate whole minute
            double totalMinute = seconds / ConstantVariables.OneMinuteInSeconds;
            return totalMinute;
        }

        /// <summary>
        /// Method for calculate Seconds
        /// </summary>
        /// <param name="seconds">Total Seconds</param>
        /// <returns>second to transfer data</returns>
        public double CalculateSeconds(double seconds)
        {
            bool IsSucess = MethodForParameterValidation(seconds);

            // Validate method input
            if (IsSucess != true)
            {
                System.Console.WriteLine("Negative value or 0 are invalid inputs");
                return seconds;
            }

            // Calculate remainder after whole minute are consumed
            seconds = seconds % ConstantVariables.OneHourInSeconds;
            // Calculate whole second
            double second = seconds % ConstantVariables.OneMinuteInSeconds;
            return second;
        }

        /// <summary>
        /// Method For Calculate the totalseconds using byte file size and transfering speed
        /// </summary>
        /// <param name="fileSizeInbyte"> converted File Size</param>
        /// <returns>Byte Data</returns>
        public double CalculateTotalSeconds(double fileSizeInbyte)
        {
            bool IsSucess = MethodForParameterValidation(fileSizeInbyte);

            // Validate method input
            if (IsSucess != true)
            {
                System.Console.WriteLine("Negative value or 0 are invalid inputs");
                return fileSizeInbyte;
            }

            // Calculate totalsecond using converted file and characters per seconds
            double totalSeconds = (fileSizeInbyte / ConstantVariables.BytePerSeconds);
            return totalSeconds;
        }

        /// <summary>
        /// Method for parameterValidation of another method
        /// </summary>
        /// <returns> True or false</returns>
        private static bool MethodForParameterValidation(double parameter)
        {
            // Check the seconds is more than 1 and not 0
            if (parameter <= 0)
            {
                return false;
            }

            return true;
        }
    }
}
