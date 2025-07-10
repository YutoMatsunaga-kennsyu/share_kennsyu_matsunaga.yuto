CREATE TABLE tasks (
  task_no int NOT NULL AUTO_INCREMENT,
  user_id VARCHAR(20) NOT NULL,
  task_name VARCHAR(15) NOT NULL,
  description VARCHAR(30),
  tag_no int NOT NULL,
  due_date DATETIME NOT NULL,
  done_date DATETIME,
  update_date DATETIME NOT NULL,
  is_active int NOT NULL,
  PRIMARY KEY(task_no),
  FOREIGN KEY (user_id) REFERENCES users(user_id),
  FOREIGN KEY (tag_no) REFERENCES task_tags(tag_no)
);
