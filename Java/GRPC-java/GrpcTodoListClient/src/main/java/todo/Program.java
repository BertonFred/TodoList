package todo;

import java.util.concurrent.TimeUnit;

import io.grpc.ManagedChannel;
import io.grpc.ManagedChannelBuilder;

public class Program {
    private static final int SERVICE_PORT = 8090;

	public static void main(String[] args) throws InterruptedException {
	    String title = "Test TODO";
	    String description = "This is a test TODO.";
	    
	    // Access a service running on the local machine
	    String target = "localhost:" + SERVICE_PORT;

	    // Create a communication channel to the service
	    ManagedChannel channel = ManagedChannelBuilder.forTarget(target)
	        // For the example we disable TLS to avoid needing certificates
	        .usePlaintext()
	        .build();
	    
	    try {
	      TodoListClient client = new TodoListClient(channel);
	      client.sendTodo(title, description);
	    } finally {
	      channel.shutdownNow().awaitTermination(5, TimeUnit.SECONDS);
	    }
    }
}
