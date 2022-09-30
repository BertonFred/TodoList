package todo;

import java.util.ArrayList;
import java.util.List;

import todo.Todo.TodoItem;
import todo.TodoListGrpc.TodoListImplBase;

public class TodoListService extends TodoListImplBase {
	
	/**
	 * La liste est maintenue en mémoire pour l'exemple
	 */
	private List<TodoRecord> todoList = new ArrayList<>();
	
    /**
     * Creation d'un item
     */
    @Override
    public void createTodoItem(todo.Todo.CreateTodoItemRequest request,
        io.grpc.stub.StreamObserver<todo.Todo.TodoItem> responseObserver) {
      System.out.println("createTodoItem");
      var titre = request.getTitre();
      var description = request.getDescription();
      todoList.add(new TodoRecord(titre, description));
      responseObserver.onNext(TodoItem
              .newBuilder()
              .setTitre(titre)
              .setDescription(description)
              .build());
      responseObserver.onCompleted();
    }

    /**
     * Lecture d'un item
     */
    @Override
    public void getTodoItem(todo.Todo.GetTodoItemRequest request,
        io.grpc.stub.StreamObserver<todo.Todo.TodoItem> responseObserver) {      
      System.out.println("getTodoItem");
      var id = request.getId();
      var todo = todoList.get(id);
      responseObserver.onNext(TodoItem
              .newBuilder()
              .setTitre(todo.titre())
              .setDescription(todo.description())
              .build());
      responseObserver.onCompleted();
    }

    /**
     * Demande la liste des items
     */
    @Override
    public void getTodoList(com.google.protobuf.Empty request,
        io.grpc.stub.StreamObserver<todo.Todo.GetTodoListReply> responseObserver) {
        System.out.println("getTodoList");
        var todoBuilder = todo.Todo.GetTodoListReply
                .newBuilder();
        for(var todo : todoList) {
            todoBuilder.setItems(0, TodoItem
            		.newBuilder()
            		.setTitre(todo.titre())
            		.setDescription(todo.description())
            		.build());
        }
        responseObserver.onNext(todoBuilder
                .build());
        responseObserver.onCompleted();
    }

}
