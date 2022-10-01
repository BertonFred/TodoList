package todo;

import io.grpc.Channel;
import todo.Todo.CreateTodoItemRequest;
import todo.Todo.TodoItem;

public class TodoListClient {

	private final TodoListGrpc.TodoListBlockingStub blockingStub;
	
	/** Construct client for accessing TodoList service using the existing channel. */
	public TodoListClient(Channel channel) {
		blockingStub = TodoListGrpc.newBlockingStub(channel);
	}
	
	public void sendTodo(String titre, String description) {
		CreateTodoItemRequest request = CreateTodoItemRequest.newBuilder()
				.setTitre(titre)
				.setDescription(description)
				.build();
		
		TodoItem reply = blockingStub.createTodoItem(request);
		System.out.println("Reply: titre: " + reply.getTitre() + ", description: " + reply.getDescription());
	}
	
}
