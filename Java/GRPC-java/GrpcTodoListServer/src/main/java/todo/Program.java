package todo;

import java.io.IOException;

import io.grpc.Server;
import io.grpc.ServerBuilder;

public class Program {
    private static final int SERVICE_PORT = 8090;

	public static void main(String[] args) throws IOException, InterruptedException {
        Server server = ServerBuilder.forPort(SERVICE_PORT).addService(new TodoListService()).build();
        server.start();
        
        System.out.println("Todo List Grpc Service started at " + server.getPort());
        
        server.awaitTermination();
    }
}
