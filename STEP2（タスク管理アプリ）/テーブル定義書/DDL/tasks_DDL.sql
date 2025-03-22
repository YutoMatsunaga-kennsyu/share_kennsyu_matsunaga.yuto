CREATE TABLE tasks (
  task_no int NOT NULL AUTO_INCREMENT,
  user_no int NOT NULL,
  task_name VARCHAR(15) NOT NULL,
  description VARCHAR(30),
  tag_no int NOT NULL,
  due_date DATE NOT NULL,
  done_date DATETIME,
  update_date DATETIME NOT NULL,
  is_active boolean NOT NULL,
  PRIMARY KEY(task_no),
  FOREIGN KEY (user_no) REFERENCES users(user_no),
  FOREIGN KEY (tag_no) REFERENCES task_tags(tag_no)
);

