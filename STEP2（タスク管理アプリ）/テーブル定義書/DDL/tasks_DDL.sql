CREATE TABLE tasks (
  user_no int NOT NULL,
  task_name VARCHAR(15) NOT NULL,
  description VARCHAR(30),
  tag VARCHAR(15) NOT NULL,
  due_date DATE NOT NULL,
  done_date DATETIME,
  update_date DATETIME NOT NULL,
  is_active boolean NOT NULL,
  PRIMARY KEY(user_no,task_name),
  FOREIGN KEY (user_no) REFERENCES users(user_no)
);

