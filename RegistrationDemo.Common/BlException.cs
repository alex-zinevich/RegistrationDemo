namespace RegistrationDemo.Common;

[Serializable]
public class BlException : Exception
{
    public BlException(ErrorCode code) : base(code.ToString("G")) 
    {
        Code = code;
    }

    public BlException(ErrorCode code, Exception e) : base(code.ToString("G") + ", see inner exception for details", e)
    {
        Code = code;
    }

    public BlException(ErrorCode code, string message, Exception e) : base(message, e)
    {
        Code = code;
    }

    public BlException(ErrorCode code, string message) : base(message)
    {
        Code = code;
    }

    public ErrorCode Code { get; set; }
}