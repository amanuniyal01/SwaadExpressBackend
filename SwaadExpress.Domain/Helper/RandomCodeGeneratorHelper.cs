using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NanoidDotNet;


    public static class RandomCodeGeneratorHelper
    {
        //private const string AllowedChars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
        private const string AllowedOTPChars = "0123456789";
      
        public static string GenerateOTP(int length = 4)
        {
            return Nanoid.Generate(AllowedOTPChars, length);
        }
    }

