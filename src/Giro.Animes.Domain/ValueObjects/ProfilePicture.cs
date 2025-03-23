using Giro.Animes.Domain.ValueObjects.Base;

namespace Giro.Animes.Domain.ValueObjects
{
    public record ProfilePicture : ValueObjectBase
    {
        public string Value { get; private set; }
        public string Format { get; private set; }
        public byte[] File { get; private set; }

        /// <summary>
        /// Construtor da classe ProfilePicture a partir do valor da foto e do formato
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <param name="file"></param>
        private ProfilePicture(string value, string format)
        {
            Value = value;
            Format = format;
        }

        /// <summary>
        /// Construtor da classe ProfilePicture a partir do arquivo e do formato da foto
        /// </summary>
        /// <param name="file"></param>
        /// <param name="format"></param>
        private ProfilePicture(byte[] file, string format)
        {
            File = file;
            Format = format;
        }

        /// <summary>
        /// Cria um objeto de valor ProfilePicture a partir do arquivo e do formato da foto 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static ProfilePicture Create(string value, string format) => new ProfilePicture(value, format);

        /// <summary>
        /// Cria um objeto de valor ProfilePicture a partir do arquivo e do formato da foto 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static ProfilePicture Create(byte[] file, string format) => new ProfilePicture(file, format);
    }
}