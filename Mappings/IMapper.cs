namespace WebApi1.Mappings
{
    public interface IMapper<Tmodel,Tdto>
    {
        public Tmodel Map(Tdto dto);
        public Tdto Map(Tmodel model);
        public Tmodel UpdateMap(Tmodel model, Tdto dto);
        public IEnumerable<Tdto> MapList(IEnumerable<Tmodel> models);
    }
}
