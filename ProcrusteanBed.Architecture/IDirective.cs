namespace ProcrusteanBed.Architecture
{
	public interface IDirective
    {
        string ParameterAlias { get; set; }	

		DirectiveType DirectiveType { get; }
    }
}
