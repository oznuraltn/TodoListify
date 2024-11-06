
using AutoMapper;
using Moq;
using TodoListify.DataAccess.Abstracts;
using TodoListify.Models.Dtos.Todos.Requests;
using TodoListify.Models.Dtos.Todos.Responses;
using TodoListify.Models.Entities;
using TodoListify.Service.Concretes;
using TodoListify.Service.Rules;

namespace TodoListify.Tests.Services
{
    [TestFixture]
    public class TodoServiceTests
    {
        private Mock<ITodoRepository> _mockTodoRepository;
        private Mock<IMapper> _mockMapper;
        private Mock<TodoBusinessRules> _mockBusinessRules;
        private TodoService _todoService;

        [SetUp]
        public void Setup()
        {
            _mockTodoRepository = new Mock<ITodoRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockBusinessRules = new Mock<TodoBusinessRules>();

            _todoService = new TodoService(
                _mockTodoRepository.Object,
                _mockMapper.Object,
                _mockBusinessRules.Object
            );
        }

        [Test]
        public void Add_ShouldReturnSuccessResponse_WhenTodoIsCreated()
        {
            var createRequest = new CreateTodoRequest("Test Title", "Test Description", 1, "userId", DateTime.Now, DateTime.Now.AddDays(1));
            var todo = new Todo { Title = "Test Title" };
            var responseDto = new TodoResponseDto { Title = "Test Title" };

            _mockMapper.Setup(m => m.Map<Todo>(createRequest)).Returns(todo);
            _mockTodoRepository.Setup(r => r.Add(todo));
            _mockMapper.Setup(m => m.Map<TodoResponseDto>(todo)).Returns(responseDto);

            var result = _todoService.Add(createRequest, "userId");

            Assert.IsTrue(result.Success);
            Assert.AreEqual("Görev eklendi", result.Message);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(responseDto.Title, result.Data.Title);
        }

        [Test]
        public void GetAll_ShouldReturnAllTodos()
        {
            var todos = new List<Todo> { new Todo { Title = "Test Todo 1" }, new Todo { Title = "Test Todo 2" } };
            var responseDtos = new List<TodoResponseDto> { new TodoResponseDto { Title = "Test Todo 1" }, new TodoResponseDto { Title = "Test Todo 2" } };

            _mockTodoRepository.Setup(r => r.GetAll()).Returns(todos);
            _mockMapper.Setup(m => m.Map<List<TodoResponseDto>>(todos)).Returns(responseDtos);

            var result = _todoService.GetAll();

            Assert.IsTrue(result.Success);
            Assert.AreEqual(2, result.Data.Count);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public void GetById_ShouldReturnTodo_WhenTodoExists()
        {
            var todoId = Guid.NewGuid();
            var todo = new Todo { Id = todoId, Title = "Test Todo" };
            var responseDto = new TodoResponseDto { Title = "Test Todo" };

            _mockTodoRepository.Setup(r => r.GetById(todoId)).Returns(todo);
            _mockMapper.Setup(m => m.Map<TodoResponseDto?>(todo)).Returns(responseDto);

            var result = _todoService.GetById(todoId);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(responseDto.Title, result.Data.Title);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public void GetById_ShouldReturnNotFound_WhenTodoDoesNotExist()
        {
            var todoId = Guid.NewGuid();

            _mockTodoRepository.Setup(r => r.GetById(todoId)).Returns((Todo)null);

            var result = _todoService.GetById(todoId);

            Assert.IsFalse(result.Success);
            Assert.AreEqual(404, result.StatusCode);
            Assert.AreEqual("Görev bulunamadı", result.Message);
        }

        [Test]
        public void Remove_ShouldReturnSuccess_WhenTodoIsDeleted()
        {
            var todoId = Guid.NewGuid();
            var todo = new Todo { Id = todoId, Title = "Test Todo" };
            var responseDto = new TodoResponseDto { Title = "Test Todo" };

            _mockTodoRepository.Setup(r => r.GetById(todoId)).Returns(todo);
            _mockTodoRepository.Setup(r => r.Remove(todo)).Returns(todo);
            _mockMapper.Setup(m => m.Map<TodoResponseDto>(todo)).Returns(responseDto);

            var result = _todoService.Remove(todoId);

            Assert.IsTrue(result.Success);
            Assert.AreEqual("Görev silindi", result.Message);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public void Remove_ShouldReturnNotFound_WhenTodoDoesNotExist()
        {
            var todoId = Guid.NewGuid();

            _mockTodoRepository.Setup(r => r.GetById(todoId)).Returns((Todo)null);

            var result = _todoService.Remove(todoId);

            Assert.IsFalse(result.Success);
            Assert.AreEqual(404, result.StatusCode);
            Assert.AreEqual("Görev bulunamadı", result.Message);
        }

        [Test]
        public void Update_ShouldReturnUpdatedTodo_WhenTodoIsUpdated()
        {
            var updateRequest = new UpdateTodoRequest(Guid.NewGuid(), "Updated Title", "Updated Description", 1, DateTime.Now, DateTime.Now.AddDays(1));
            var todo = new Todo { Id = updateRequest.Id, Title = "Old Title" };
            var updatedTodo = new Todo { Id = updateRequest.Id, Title = "Updated Title" };
            var responseDto = new TodoResponseDto { Title = "Updated Title" };

            _mockTodoRepository.Setup(r => r.GetById(updateRequest.Id)).Returns(todo);
            _mockMapper.Setup(m => m.Map(updateRequest, todo)).Returns(updatedTodo);
            _mockTodoRepository.Setup(r => r.Update(updatedTodo)).Returns(updatedTodo);
            _mockMapper.Setup(m => m.Map<TodoResponseDto>(updatedTodo)).Returns(responseDto);

            var result = _todoService.Update(updateRequest);

            Assert.IsTrue(result.Success);
            Assert.AreEqual("Görev güncellendi", result.Message);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(responseDto.Title, result.Data.Title);
        }

        [Test]
        public void Update_ShouldReturnNotFound_WhenTodoDoesNotExist()
        {
            var updateRequest = new UpdateTodoRequest(Guid.NewGuid(), "Updated Title", "Updated Description", 1, DateTime.Now, DateTime.Now.AddDays(1));

            _mockTodoRepository.Setup(r => r.GetById(updateRequest.Id)).Returns((Todo)null);

            var result = _todoService.Update(updateRequest);

            Assert.IsFalse(result.Success);
            Assert.AreEqual(404, result.StatusCode);
            Assert.AreEqual("Görev bulunamadı", result.Message);
        }
    }
}
