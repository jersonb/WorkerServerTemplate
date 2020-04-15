using Microsoft.Extensions.Configuration;
using WorkerService.Manager;
using Xunit;

namespace Test
{
    public class SendEmailTest
    {
        public static IConfigurationRoot Configuration { get; set; }
        public SendEmailTest()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(@"C:\Users\User\Documents\Projetos\WorkerService\WorkerService")
                .AddJsonFile("appsettings.Development.json");
            Configuration = builder.Build();

        }

        [Fact]
        public void SendEmailOkTest()
        {
            try
            {
                new EmailManager(Configuration).Send("Tudo certo com o teste!");
                Assert.True(true);
            }
            catch (System.Exception ex)
            {

                Assert.Null(ex);
            }
        }

        [Fact]
        public void SendEmailExceptionTest()
        {
            try
            {

                throw new System.InvalidOperationException("Teste email, envio por erro");
            }
            catch (System.Exception ex)
            {
                try
                {
                    new EmailManager(Configuration).Send(ex);
                }
                catch (System.Exception exception)
                {

                    Assert.Null(exception);

                }

            }
        }
    }
}
