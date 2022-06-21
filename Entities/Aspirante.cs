using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using WebApiKalum.Helpers;

namespace WebApiKalum.Entities
{
    public class Aspirante //: IValidatableObject
    {
        [Required(ErrorMessage = "El campo {0} no debe ser vacio")]
        [StringLength(12,MinimumLength =12, ErrorMessage = "El campo numero de expediente debe ser 12 caracteres")]
        [NoExpediente]
        public string NoExpediente { get; set; }
        [Required(ErrorMessage = "El campo {0} no debe ser vacio")]
        public string Apellidos {get; set; }
        [Required(ErrorMessage = "El campo {0} no debe ser vacio")]
        public string Nombres {get;set;}
        [Required(ErrorMessage = "El campo {0} no debe ser vacio")]
        public string Direccion {get; set; }
        [Required(ErrorMessage = "El campo {0} no debe ser vacio")]
        public string Telefono {get; set;}
        [Required(ErrorMessage = "El correo electronico no es valido")]
        public string Email {get; set; }
        public string Estatus {get; set; } = "NO ASIGNADO";
        public string CarreraId {get; set; }
        public string JornadaId {get; set; }
        public string ExamenId {get; set; }
        public virtual CarreraTecnica CarreraTecnica {get; set; }
        public virtual Jornada Jornada {get; set; }
        public virtual ExamenAdmision ExamenAdmision {get; set; }
        public virtual List<ResultadoExamenAdmision> ResultadosExamenAdmisiones {get; set; }
        public virtual List<InscripcionPago> IncripcionesPagos {get; set; }

        /*public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            //bool expedienteValid = false;

            if(!string.IsNullOrEmpty(NoExpediente))
            
            {
                if(!NoExpediente.Contains("_"))
                {
                    yield return new ValidationResult("El numero de expediente es invalido, no contiene '-' ", new string[]{nameof(NoExpediente)});
                }else
                {
                int guion = NoExpediente.IndexOf("-"); 
                string exp = NoExpediente.Substring(0,guion);
                string numero = NoExpediente.Substring(guion+1,NoExpediente.Length - 4);
                if(!exp.ToUpper().Equals("EXP") || !Information.IsNumeric(numero))
                {
                    yield return new ValidationResult("El numero de expediente no contiene la nomenclatura adecauada", new string[]{nameof(NoExpediente)});
                }
                }
            }
        }*/
    }
}