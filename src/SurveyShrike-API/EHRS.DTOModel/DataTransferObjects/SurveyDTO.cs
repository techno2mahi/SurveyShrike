using System;
using System.Runtime.Serialization;
using EHRS.Shared;

namespace EHRS.DTOModel
{
    /// <summary>
    /// Survey DTO .
    /// </summary>
    /// <seealso cref="EHRS.Shared.DTOBase" />
    /// <seealso cref="EHRS.Shared.ISurveyDTO" />
    [DataContract(Name = "Survey", Namespace = "EHRS.DTOModel")]
    [EntityMapping("EntityDataModel.EntityModels.Survey", MappingType.TotalExplicit)]
    [ViewModelMapping("EHRS.Web.Shared.ViewModels.SurveyViewModel", MappingType.TotalExplicit)]
    [Serializable]
    public class SurveyDTO : DTOBase, ISurveyDTO
    {

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [ViewModelPropertyMapping(MappingDirectionType.Both, "Id")]
        [EntityPropertyMapping(MappingDirectionType.Both, "Id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        [ViewModelPropertyMapping(MappingDirectionType.Both, "SurveyTitle")]
        [EntityPropertyMapping(MappingDirectionType.Both, "SurveyTitle")]
        public string SurveyTitle { get; set; }

        /// <summary>
        /// Gets or sets the CreatedOn.
        /// </summary>
        [ViewModelPropertyMapping(MappingDirectionType.Both, "CreatedOn")]
        [EntityPropertyMapping(MappingDirectionType.Both, "CreatedOn")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the CreatedBy.
        /// </summary>
        [ViewModelPropertyMapping(MappingDirectionType.Both, "CreatedBy")]
        [EntityPropertyMapping(MappingDirectionType.Both, "CreatedBy")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the ModifiedOn.
        /// </summary>
        [ViewModelPropertyMapping(MappingDirectionType.Both, "ModifiedOn")]
        [EntityPropertyMapping(MappingDirectionType.Both, "ModifiedOn")]
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// Gets or sets the ModifiedBy.
        /// </summary>
        [ViewModelPropertyMapping(MappingDirectionType.Both, "ModifiedBy")]
        [EntityPropertyMapping(MappingDirectionType.Both, "ModifiedBy")]
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the IsDeleted.
        /// </summary>
        [ViewModelPropertyMapping(MappingDirectionType.Both, "IsDeleted")]
        [EntityPropertyMapping(MappingDirectionType.Both, "IsDeleted")]
        public bool IsDeleted { get; set; }
    }
}