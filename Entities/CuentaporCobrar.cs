namespace WebApiKalum.Entities
{
    public class CuentaporCobrar
    {
        public string Correlativo { get; set; }
        public string Anio { get; set; }
        public string Carne { get; set; }
        public string CargoId { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaExamen { get; set; }
        public DateTime FechaAplicacion { get; set; }
        public double Monto { get; set; }
        public double Mora { get; set;}
        public double Descuenta { get; set;}
        public virtual Alumno Alumno { get; set; }
        public virtual Cargo Cargo { get; set; }
    }
}