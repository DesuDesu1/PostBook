using PostBook.Contract;
using PostBook.Controllers.V1.Requests;
using PostBook.Domain;
using PostBook.IntegrationTests.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PostBook.IntegrationTests
{
    public class PostsControllerTest: IntegrationTest
    {
        [Fact]
        public async Task GetAll_WithEmptyOrWithoutAnyPosts_ReturnsEmptyResponse()
        {
            //Arrange
            await AuthenticateAsync();
            //Act
            var response = await _httpClient.GetAsync(ApiRoutes.Posts.GetAll);
            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Empty(await response.Content.ReadAsAsync<List<Post>>());
        }
        [Fact]
        public async Task Get_ReturnsPost_WhenPostExistsInTheDatabase()
        {
            // Arrange
            await AuthenticateAsync();
            var createdPost = await CreatePostAsync(new CreatePostRequest { Name = "Test post" });

            // Act
            var response = await _httpClient.GetAsync(ApiRoutes.Posts.Get.Replace("{postId}", createdPost.Id.ToString()));

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var returnedPost = await response.Content.ReadAsAsync<Post>();
            //returnedPost.Id.Should().Be(createdPost.Id);
            Assert.Equal(returnedPost.Id, createdPost.Id);
            Assert.Equal(returnedPost.Name, "Test post");
        }
    }
}
