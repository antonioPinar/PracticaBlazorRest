using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace PracticaBlazorRest.Shared.Models
{
    [DataContract(IsReference = false, Name = "UserClient", Namespace = "http://nivaes")]
    public class Contact
    {
        [Key]
        [DataMember(Name = "IdUser")]
        public Guid Id { get; set; }

        #region TaxVat
        [IgnoreDataMember]
        private string mTaxVat;

        [DataMember(Name = "TaxVat")]
        [MaxLength(20)]
        [ConcurrencyCheck]
        [Required]
        public string TaxVat
        {
            get => mTaxVat;
            set => mTaxVat = value;
        }
        #endregion

        #region HonorificNamePrefix
        [IgnoreDataMember]
        private string mHonorificNamePrefix;

        [MaxLength(10)]
        [DataMember(Name = "HonorificNamePrefix")]
        public string HonorificNamePrefix
        {
            get => mHonorificNamePrefix;
            set => mHonorificNamePrefix = value;
        }
        #endregion

        #region HonorificNameSuffix
        [IgnoreDataMember]
        private string mHonorificNameSuffix;

        [MaxLength(10)]
        [DataMember(Name = "HonorificNameSuffix")]
        public string HonorificNameSuffix
        {
            get => mHonorificNameSuffix;
            set => mHonorificNameSuffix = value;
        }
        #endregion

        #region PersonalName
        [IgnoreDataMember]
        private string mPersonalName;

        [DataMember(Name = "PersonalName")]
        [MaxLength(500)]
        public string PersonalName
        {
            get => mPersonalName;
            set => mPersonalName = value;
        }
        #endregion

        #region FamilyName
        [IgnoreDataMember]
        private string mFamilyName;

        [DataMember(Name = "FamilyName")]
        [MaxLength(500)]
        public string FamilyName
        {
            get => mFamilyName;
            set => mFamilyName = value;
        }
        #endregion

        [IgnoreDataMember]
        public string FullName => string.Join(" ", new string[] { mHonorificNamePrefix, mPersonalName, mFamilyName, mHonorificNameSuffix }.Where(s => !string.IsNullOrEmpty(s)));

        [IgnoreDataMember]
        public string Initials => mPersonalName?.Substring(0, 1) + mFamilyName?.Substring(0, 1);

        #region PhoneNumber
        private string mPhoneNumber;

        [DataMember(Name = "PhoneNumber")]
        [MaxLength(30)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber
        {
            get => mPhoneNumber;
            set => mPhoneNumber = value;
        }
        #endregion

        #region Email
        private string mEmail;

        [DataMember(Name = "Email")]
        [MaxLength(1024)]
        [DataType(DataType.EmailAddress)]
        public string Email
        {
            get => mEmail;
            set => mEmail = value;
        }
        #endregion

        #region Notes
        private string mNotes;

        [DataMember(Name = "Notes")]
        [MaxLength(1024)]
        [DataType(DataType.EmailAddress)]
        public string Notes
        {
            get => mNotes;
            set => mNotes = value;
        }
        #endregion
    }
}
