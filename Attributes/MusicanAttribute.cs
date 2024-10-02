using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Threading.Channels;
using System.Threading;

namespace CreazyMusicans.Attributes
{
    public class MusicanAttribute:ValidationAttribute
    {
        //we created custom validation property for the our project 
        private readonly string[] _funny = new[]
        {
            //it is have value at list
            "Always hits the wrong note but it's so much fun",
            "Their songs are misunderstood but very popular",
            "He changes chords often, but he is surprisingly talent",
            "He always prepares surprises while producing notes."
        };

        public int Funny  { get; } // we defined property for the attribute
      
        public MusicanAttribute(int funny=1) // we assign default value 
        
        {
            Funny = funny;
          
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) // we use the Isvalid method
        {
            if (value is string copm)

            {

                var funnys=copm.Split(',').Select(f=>f.Trim()).ToList();

                if (funnys.Count<Funny) {

                    return new ValidationResult($"It is must be selected{Funny}");
                }
                var invalidFunny=funnys.Except(_funny,StringComparer.OrdinalIgnoreCase).ToList();
                if (invalidFunny.Any()) {

                    return new ValidationResult("inavlid funny");
                }
            }
            else {
                return new ValidationResult("It is not valid.");
            }

            return ValidationResult.Success;//If user leave the emty or misatke value input our validaon to be run
        }

    }
}
