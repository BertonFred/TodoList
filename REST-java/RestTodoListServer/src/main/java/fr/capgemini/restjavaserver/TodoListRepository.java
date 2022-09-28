package fr.capgemini.restjavaserver;

import org.springframework.data.repository.CrudRepository;

public interface TodoListRepository extends CrudRepository<Todo, Long> {}
