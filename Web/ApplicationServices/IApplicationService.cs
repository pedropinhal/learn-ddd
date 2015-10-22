using Web.Models;

namespace Web.ApplicationServices
{
    public interface IApplicationService
    {
        IndexViewModel GetFixtures();
        void CreateFixture();
    }
}