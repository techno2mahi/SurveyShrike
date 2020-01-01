using System;
using System.Runtime.Serialization;
using EHRS.Shared;

namespace EHRS.DTOModel
{
    /// <summary>
    /// PersonDTO DTO.
    /// </summary>
    /// <seealso cref="EHRS.Shared.DTOBase"/>
    /// <seealso cref="EHRS.Shared.IPersonDTO"/>
    [DataContract(Name = "Person", Namespace = "EHRS.DTOModel")]
    [EntityMapping("EntityDataModel.EntityModels.Person", MappingType.TotalExplicit)]
    [Serializable]
    [ViewModelMapping("EHRS.Web.Shared.ViewModels.PersonViewModel", MappingType.TotalExplicit)]
    public class PersonDTO : DTOBase, IPersonDTO
    {
        /// <summary>
        /// Gets or sets the Person identifier.
        /// </summary>
        /// <value>
        /// The Person identifier.
        /// </value>
        [ViewModelPropertyMapping(MappingDirectionType.Both, "Id")]
        [EntityPropertyMapping(MappingDirectionType.Both, "Id")]
        public int Id{ get; set; }

        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [ViewModelPropertyMapping(MappingDirectionType.Both, "Name")]
        [EntityPropertyMapping(MappingDirectionType.Both, "Name")]
        public string Name { get; set; }

        [ViewModelPropertyMapping(MappingDirectionType.Both, "FirstName")]
        [EntityPropertyMapping(MappingDirectionType.Both, "FirstName")]
        public string FirstName { get; set; }


        [ViewModelPropertyMapping(MappingDirectionType.Both, "LastName")]
        [EntityPropertyMapping(MappingDirectionType.Both, "LastName")]
        public string LastName { get; set; }

        [ViewModelPropertyMapping(MappingDirectionType.Both, "ParentName")]
        [EntityPropertyMapping(MappingDirectionType.Both, "ParentName")]
        public string ParentName { get; set; }

        

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        [ViewModelPropertyMapping(MappingDirectionType.Both, "MobileNumber")]
        [EntityPropertyMapping(MappingDirectionType.Both, "MobileNumber")]
        public string MobileNumber { get; set; }

       

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        [ViewModelPropertyMapping(MappingDirectionType.Both, "City")]
        public string City { get; set; }

        

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        [ViewModelPropertyMapping(MappingDirectionType.Both, "Address")]
        [EntityPropertyMapping(MappingDirectionType.Both, "Address")]
        public string Address { get; set; }

        public DateTime DOB { get; set; }
        public DateTime EnrolledOn { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        /// <value>
        /// The created on.
        /// </value>
        [ViewModelPropertyMapping(MappingDirectionType.Both, "CreatedOn")]
        [EntityPropertyMapping(MappingDirectionType.Both, "CreatedOn")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        [ViewModelPropertyMapping(MappingDirectionType.Both, "CreatedBy")]
        [EntityPropertyMapping(MappingDirectionType.Both, "CreatedBy")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the owner identifier.
        /// </summary>
        /// <value>
        /// The owner identifier.
        /// </value>
        [ViewModelPropertyMapping(MappingDirectionType.Both, "OwnerId")]
        [EntityPropertyMapping(MappingDirectionType.Both, "OwnerId")]
        public string OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the updated on.
        /// </summary>
        /// <value>
        /// The updated on.
        /// </value>
        [ViewModelPropertyMapping(MappingDirectionType.Both, "UpdatedOn")]
        [EntityPropertyMapping(MappingDirectionType.Both, "UpdatedOn")]
        public DateTime UpdatedOn { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        [ViewModelPropertyMapping(MappingDirectionType.Both, "UpdatedBy")]
        [EntityPropertyMapping(MappingDirectionType.Both, "UpdatedBy")]
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        [ViewModelPropertyMapping(MappingDirectionType.Both, "IsActive")]
        [EntityPropertyMapping(MappingDirectionType.Both, "IsActive")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        [EntityPropertyMapping(MappingDirectionType.Both, "IsDeleted")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "IsDeleted")]
        public bool IsDeleted { get; set; }
    }
}
