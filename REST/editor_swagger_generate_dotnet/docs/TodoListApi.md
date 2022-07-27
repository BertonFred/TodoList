# IO.Swagger.Api.TodoListApi

All URIs are relative to */*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateTodoItem**](TodoListApi.md#createtodoitem) | **POST** /api/v1/TodoList/CreateTodoItem | 
[**DeleteTodoItem**](TodoListApi.md#deletetodoitem) | **DELETE** /api/v1/TodoList/DeleteTodoItem/{id} | 
[**GetTodoItem**](TodoListApi.md#gettodoitem) | **GET** /api/v1/TodoList/GetTodoItem/{id} | 
[**GetTodoItems**](TodoListApi.md#gettodoitems) | **GET** /api/v1/TodoList | 
[**UpdateTodoItem**](TodoListApi.md#updatetodoitem) | **PUT** /api/v1/TodoList/UpdateTodoItem/{id} | 

<a name="createtodoitem"></a>
# **CreateTodoItem**
> void CreateTodoItem (CreateOrUpdateTodoItem body)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CreateTodoItemExample
    {
        public void main()
        {

            var apiInstance = new TodoListApi();
            var body = new CreateOrUpdateTodoItem(); // CreateOrUpdateTodoItem |  (optional) 

            try
            {
                apiInstance.CreateTodoItem(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TodoListApi.CreateTodoItem: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**CreateOrUpdateTodoItem**](CreateOrUpdateTodoItem.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deletetodoitem"></a>
# **DeleteTodoItem**
> void DeleteTodoItem (int? id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class DeleteTodoItemExample
    {
        public void main()
        {

            var apiInstance = new TodoListApi();
            var id = 56;  // int? | 

            try
            {
                apiInstance.DeleteTodoItem(id);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TodoListApi.DeleteTodoItem: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="gettodoitem"></a>
# **GetTodoItem**
> TodoItem GetTodoItem (int? id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetTodoItemExample
    {
        public void main()
        {

            var apiInstance = new TodoListApi();
            var id = 56;  // int? | 

            try
            {
                TodoItem result = apiInstance.GetTodoItem(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TodoListApi.GetTodoItem: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 

### Return type

[**TodoItem**](TodoItem.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="gettodoitems"></a>
# **GetTodoItems**
> List<TodoItem> GetTodoItems ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetTodoItemsExample
    {
        public void main()
        {

            var apiInstance = new TodoListApi();

            try
            {
                List&lt;TodoItem&gt; result = apiInstance.GetTodoItems();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TodoListApi.GetTodoItems: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<TodoItem>**](TodoItem.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatetodoitem"></a>
# **UpdateTodoItem**
> void UpdateTodoItem (int? id, CreateOrUpdateTodoItem body)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UpdateTodoItemExample
    {
        public void main()
        {

            var apiInstance = new TodoListApi();
            var id = 56;  // int? | 
            var body = new CreateOrUpdateTodoItem(); // CreateOrUpdateTodoItem |  (optional) 

            try
            {
                apiInstance.UpdateTodoItem(id, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TodoListApi.UpdateTodoItem: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 
 **body** | [**CreateOrUpdateTodoItem**](CreateOrUpdateTodoItem.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

