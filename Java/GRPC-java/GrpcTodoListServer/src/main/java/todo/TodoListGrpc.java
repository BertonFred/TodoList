package todo;

import static io.grpc.MethodDescriptor.generateFullMethodName;

/**
 * <pre>
 * Définition du service de gestion des todo listes
 * La todo liste est composée de todo item
 * </pre>
 */
@javax.annotation.Generated(
    value = "by gRPC proto compiler (version 1.49.1)",
    comments = "Source: Todo.proto")
@io.grpc.stub.annotations.GrpcGenerated
public final class TodoListGrpc {

  private TodoListGrpc() {}

  public static final String SERVICE_NAME = "todo.TodoList";

  // Static method descriptors that strictly reflect the proto.
  private static volatile io.grpc.MethodDescriptor<todo.Todo.CreateTodoItemRequest,
      todo.Todo.TodoItem> getCreateTodoItemMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "CreateTodoItem",
      requestType = todo.Todo.CreateTodoItemRequest.class,
      responseType = todo.Todo.TodoItem.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<todo.Todo.CreateTodoItemRequest,
      todo.Todo.TodoItem> getCreateTodoItemMethod() {
    io.grpc.MethodDescriptor<todo.Todo.CreateTodoItemRequest, todo.Todo.TodoItem> getCreateTodoItemMethod;
    if ((getCreateTodoItemMethod = TodoListGrpc.getCreateTodoItemMethod) == null) {
      synchronized (TodoListGrpc.class) {
        if ((getCreateTodoItemMethod = TodoListGrpc.getCreateTodoItemMethod) == null) {
          TodoListGrpc.getCreateTodoItemMethod = getCreateTodoItemMethod =
              io.grpc.MethodDescriptor.<todo.Todo.CreateTodoItemRequest, todo.Todo.TodoItem>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "CreateTodoItem"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  todo.Todo.CreateTodoItemRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  todo.Todo.TodoItem.getDefaultInstance()))
              .setSchemaDescriptor(new TodoListMethodDescriptorSupplier("CreateTodoItem"))
              .build();
        }
      }
    }
    return getCreateTodoItemMethod;
  }

  private static volatile io.grpc.MethodDescriptor<todo.Todo.GetTodoItemRequest,
      todo.Todo.TodoItem> getGetTodoItemMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "GetTodoItem",
      requestType = todo.Todo.GetTodoItemRequest.class,
      responseType = todo.Todo.TodoItem.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<todo.Todo.GetTodoItemRequest,
      todo.Todo.TodoItem> getGetTodoItemMethod() {
    io.grpc.MethodDescriptor<todo.Todo.GetTodoItemRequest, todo.Todo.TodoItem> getGetTodoItemMethod;
    if ((getGetTodoItemMethod = TodoListGrpc.getGetTodoItemMethod) == null) {
      synchronized (TodoListGrpc.class) {
        if ((getGetTodoItemMethod = TodoListGrpc.getGetTodoItemMethod) == null) {
          TodoListGrpc.getGetTodoItemMethod = getGetTodoItemMethod =
              io.grpc.MethodDescriptor.<todo.Todo.GetTodoItemRequest, todo.Todo.TodoItem>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "GetTodoItem"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  todo.Todo.GetTodoItemRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  todo.Todo.TodoItem.getDefaultInstance()))
              .setSchemaDescriptor(new TodoListMethodDescriptorSupplier("GetTodoItem"))
              .build();
        }
      }
    }
    return getGetTodoItemMethod;
  }

  private static volatile io.grpc.MethodDescriptor<com.google.protobuf.Empty,
      todo.Todo.GetTodoListReply> getGetTodoListMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "GetTodoList",
      requestType = com.google.protobuf.Empty.class,
      responseType = todo.Todo.GetTodoListReply.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<com.google.protobuf.Empty,
      todo.Todo.GetTodoListReply> getGetTodoListMethod() {
    io.grpc.MethodDescriptor<com.google.protobuf.Empty, todo.Todo.GetTodoListReply> getGetTodoListMethod;
    if ((getGetTodoListMethod = TodoListGrpc.getGetTodoListMethod) == null) {
      synchronized (TodoListGrpc.class) {
        if ((getGetTodoListMethod = TodoListGrpc.getGetTodoListMethod) == null) {
          TodoListGrpc.getGetTodoListMethod = getGetTodoListMethod =
              io.grpc.MethodDescriptor.<com.google.protobuf.Empty, todo.Todo.GetTodoListReply>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "GetTodoList"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  com.google.protobuf.Empty.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  todo.Todo.GetTodoListReply.getDefaultInstance()))
              .setSchemaDescriptor(new TodoListMethodDescriptorSupplier("GetTodoList"))
              .build();
        }
      }
    }
    return getGetTodoListMethod;
  }

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static TodoListStub newStub(io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<TodoListStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<TodoListStub>() {
        @java.lang.Override
        public TodoListStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new TodoListStub(channel, callOptions);
        }
      };
    return TodoListStub.newStub(factory, channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static TodoListBlockingStub newBlockingStub(
      io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<TodoListBlockingStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<TodoListBlockingStub>() {
        @java.lang.Override
        public TodoListBlockingStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new TodoListBlockingStub(channel, callOptions);
        }
      };
    return TodoListBlockingStub.newStub(factory, channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary calls on the service
   */
  public static TodoListFutureStub newFutureStub(
      io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<TodoListFutureStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<TodoListFutureStub>() {
        @java.lang.Override
        public TodoListFutureStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new TodoListFutureStub(channel, callOptions);
        }
      };
    return TodoListFutureStub.newStub(factory, channel);
  }

  /**
   * <pre>
   * Définition du service de gestion des todo listes
   * La todo liste est composée de todo item
   * </pre>
   */
  public static abstract class TodoListImplBase implements io.grpc.BindableService {

    /**
     * <pre>
     * Creation d'une item de todo
     * </pre>
     */
    public void createTodoItem(todo.Todo.CreateTodoItemRequest request,
        io.grpc.stub.StreamObserver<todo.Todo.TodoItem> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getCreateTodoItemMethod(), responseObserver);
    }

    /**
     * <pre>
     * Lecture d'un todo item
     * </pre>
     */
    public void getTodoItem(todo.Todo.GetTodoItemRequest request,
        io.grpc.stub.StreamObserver<todo.Todo.TodoItem> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getGetTodoItemMethod(), responseObserver);
    }

    /**
     * <pre>
     * Demande la liste des todo items
     * </pre>
     */
    public void getTodoList(com.google.protobuf.Empty request,
        io.grpc.stub.StreamObserver<todo.Todo.GetTodoListReply> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getGetTodoListMethod(), responseObserver);
    }

    @java.lang.Override public final io.grpc.ServerServiceDefinition bindService() {
      return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
          .addMethod(
            getCreateTodoItemMethod(),
            io.grpc.stub.ServerCalls.asyncUnaryCall(
              new MethodHandlers<
                todo.Todo.CreateTodoItemRequest,
                todo.Todo.TodoItem>(
                  this, METHODID_CREATE_TODO_ITEM)))
          .addMethod(
            getGetTodoItemMethod(),
            io.grpc.stub.ServerCalls.asyncUnaryCall(
              new MethodHandlers<
                todo.Todo.GetTodoItemRequest,
                todo.Todo.TodoItem>(
                  this, METHODID_GET_TODO_ITEM)))
          .addMethod(
            getGetTodoListMethod(),
            io.grpc.stub.ServerCalls.asyncUnaryCall(
              new MethodHandlers<
                com.google.protobuf.Empty,
                todo.Todo.GetTodoListReply>(
                  this, METHODID_GET_TODO_LIST)))
          .build();
    }
  }

  /**
   * <pre>
   * Définition du service de gestion des todo listes
   * La todo liste est composée de todo item
   * </pre>
   */
  public static final class TodoListStub extends io.grpc.stub.AbstractAsyncStub<TodoListStub> {
    private TodoListStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected TodoListStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new TodoListStub(channel, callOptions);
    }

    /**
     * <pre>
     * Creation d'une item de todo
     * </pre>
     */
    public void createTodoItem(todo.Todo.CreateTodoItemRequest request,
        io.grpc.stub.StreamObserver<todo.Todo.TodoItem> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
          getChannel().newCall(getCreateTodoItemMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     * <pre>
     * Lecture d'un todo item
     * </pre>
     */
    public void getTodoItem(todo.Todo.GetTodoItemRequest request,
        io.grpc.stub.StreamObserver<todo.Todo.TodoItem> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
          getChannel().newCall(getGetTodoItemMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     * <pre>
     * Demande la liste des todo items
     * </pre>
     */
    public void getTodoList(com.google.protobuf.Empty request,
        io.grpc.stub.StreamObserver<todo.Todo.GetTodoListReply> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
          getChannel().newCall(getGetTodoListMethod(), getCallOptions()), request, responseObserver);
    }
  }

  /**
   * <pre>
   * Définition du service de gestion des todo listes
   * La todo liste est composée de todo item
   * </pre>
   */
  public static final class TodoListBlockingStub extends io.grpc.stub.AbstractBlockingStub<TodoListBlockingStub> {
    private TodoListBlockingStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected TodoListBlockingStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new TodoListBlockingStub(channel, callOptions);
    }

    /**
     * <pre>
     * Creation d'une item de todo
     * </pre>
     */
    public todo.Todo.TodoItem createTodoItem(todo.Todo.CreateTodoItemRequest request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
          getChannel(), getCreateTodoItemMethod(), getCallOptions(), request);
    }

    /**
     * <pre>
     * Lecture d'un todo item
     * </pre>
     */
    public todo.Todo.TodoItem getTodoItem(todo.Todo.GetTodoItemRequest request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
          getChannel(), getGetTodoItemMethod(), getCallOptions(), request);
    }

    /**
     * <pre>
     * Demande la liste des todo items
     * </pre>
     */
    public todo.Todo.GetTodoListReply getTodoList(com.google.protobuf.Empty request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
          getChannel(), getGetTodoListMethod(), getCallOptions(), request);
    }
  }

  /**
   * <pre>
   * Définition du service de gestion des todo listes
   * La todo liste est composée de todo item
   * </pre>
   */
  public static final class TodoListFutureStub extends io.grpc.stub.AbstractFutureStub<TodoListFutureStub> {
    private TodoListFutureStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected TodoListFutureStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new TodoListFutureStub(channel, callOptions);
    }

    /**
     * <pre>
     * Creation d'une item de todo
     * </pre>
     */
    public com.google.common.util.concurrent.ListenableFuture<todo.Todo.TodoItem> createTodoItem(
        todo.Todo.CreateTodoItemRequest request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
          getChannel().newCall(getCreateTodoItemMethod(), getCallOptions()), request);
    }

    /**
     * <pre>
     * Lecture d'un todo item
     * </pre>
     */
    public com.google.common.util.concurrent.ListenableFuture<todo.Todo.TodoItem> getTodoItem(
        todo.Todo.GetTodoItemRequest request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
          getChannel().newCall(getGetTodoItemMethod(), getCallOptions()), request);
    }

    /**
     * <pre>
     * Demande la liste des todo items
     * </pre>
     */
    public com.google.common.util.concurrent.ListenableFuture<todo.Todo.GetTodoListReply> getTodoList(
        com.google.protobuf.Empty request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
          getChannel().newCall(getGetTodoListMethod(), getCallOptions()), request);
    }
  }

  private static final int METHODID_CREATE_TODO_ITEM = 0;
  private static final int METHODID_GET_TODO_ITEM = 1;
  private static final int METHODID_GET_TODO_LIST = 2;

  private static final class MethodHandlers<Req, Resp> implements
      io.grpc.stub.ServerCalls.UnaryMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ServerStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ClientStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.BidiStreamingMethod<Req, Resp> {
    private final TodoListImplBase serviceImpl;
    private final int methodId;

    MethodHandlers(TodoListImplBase serviceImpl, int methodId) {
      this.serviceImpl = serviceImpl;
      this.methodId = methodId;
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_CREATE_TODO_ITEM:
          serviceImpl.createTodoItem((todo.Todo.CreateTodoItemRequest) request,
              (io.grpc.stub.StreamObserver<todo.Todo.TodoItem>) responseObserver);
          break;
        case METHODID_GET_TODO_ITEM:
          serviceImpl.getTodoItem((todo.Todo.GetTodoItemRequest) request,
              (io.grpc.stub.StreamObserver<todo.Todo.TodoItem>) responseObserver);
          break;
        case METHODID_GET_TODO_LIST:
          serviceImpl.getTodoList((com.google.protobuf.Empty) request,
              (io.grpc.stub.StreamObserver<todo.Todo.GetTodoListReply>) responseObserver);
          break;
        default:
          throw new AssertionError();
      }
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public io.grpc.stub.StreamObserver<Req> invoke(
        io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        default:
          throw new AssertionError();
      }
    }
  }

  private static abstract class TodoListBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoFileDescriptorSupplier, io.grpc.protobuf.ProtoServiceDescriptorSupplier {
    TodoListBaseDescriptorSupplier() {}

    @java.lang.Override
    public com.google.protobuf.Descriptors.FileDescriptor getFileDescriptor() {
      return todo.Todo.getDescriptor();
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.ServiceDescriptor getServiceDescriptor() {
      return getFileDescriptor().findServiceByName("TodoList");
    }
  }

  private static final class TodoListFileDescriptorSupplier
      extends TodoListBaseDescriptorSupplier {
    TodoListFileDescriptorSupplier() {}
  }

  private static final class TodoListMethodDescriptorSupplier
      extends TodoListBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoMethodDescriptorSupplier {
    private final String methodName;

    TodoListMethodDescriptorSupplier(String methodName) {
      this.methodName = methodName;
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.MethodDescriptor getMethodDescriptor() {
      return getServiceDescriptor().findMethodByName(methodName);
    }
  }

  private static volatile io.grpc.ServiceDescriptor serviceDescriptor;

  public static io.grpc.ServiceDescriptor getServiceDescriptor() {
    io.grpc.ServiceDescriptor result = serviceDescriptor;
    if (result == null) {
      synchronized (TodoListGrpc.class) {
        result = serviceDescriptor;
        if (result == null) {
          serviceDescriptor = result = io.grpc.ServiceDescriptor.newBuilder(SERVICE_NAME)
              .setSchemaDescriptor(new TodoListFileDescriptorSupplier())
              .addMethod(getCreateTodoItemMethod())
              .addMethod(getGetTodoItemMethod())
              .addMethod(getGetTodoListMethod())
              .build();
        }
      }
    }
    return result;
  }
}
