using AlertToCareAPI.Models;
using System;


namespace AlertToCareAPI.Utility
{
    public class ValidationsIcu
    {

        public bool ValidateIcu(Icu icu)
        {

            if (String.IsNullOrEmpty(icu.Id) || String.IsNullOrEmpty(icu.LayoutId))
            {
                return false;
            }
            return true;

        }

    }
}
