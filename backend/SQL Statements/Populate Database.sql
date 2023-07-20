INSERT INTO roles (role_id, role_name)
VALUES (0, 'admin'), (1, 'user');

INSERT INTO users (user_id, role_id, user_name, sign_up_date, password, email, user_standing)
VALUES 
	(0, 0, 'testAdmin', '2022-07-20', 'adminPassword', 'admin@example.com', 'normal'),
	(1, 1, 'userOne', '2022-08-20', 'userOnePassword', 'userOne@example.com', 'normal'),
	(2, 1, 'userTwo', '2022-09-01', 'userTwoPassword', 'userTwo@example.com', 'normal'),
	(3, 1, 'userThree', '2022-10-15', 'userThreePassword', 'userThree@example.com', 'suspended'),
	(4, 1, 'userFour', '2022-11-09', 'userFourPassword', 'userFour@example.com', 'banned');

INSERT INTO posts (post_id, author_id, post_title, publish_date, post_text)
VALUES 
	(0, 0, 'First Post', '2022-07-20', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ullamcorper auctor purus a laoreet. Fusce venenatis suscipit quam, in dictum justo congue non. Nullam at tincidunt lorem, sit amet consequat neque. Nulla facilisi. Ut tristique, enim id mollis viverra, erat massa vehicula felis, sit amet varius purus elit vel massa. Integer bibendum quam in sapien dictum, eu scelerisque ex faucibus. Curabitur posuere, felis a facilisis tempus, purus nibh ullamcorper arcu, ac maximus ipsum est eu sem. Sed pharetra metus in lacus aliquam dignissim. Vivamus eu sem quis elit sollicitudin convallis. Sed at quam facilisis, volutpat mauris a, tincidunt enim.

	Duis tincidunt, sapien eu luctus elementum, urna quam ultricies libero, eu congue est tortor vel justo. Nunc consequat consectetur sapien, nec rhoncus ipsum interdum sit amet. Fusce iaculis mauris in ex dignissim tincidunt. In hac habitasse platea dictumst. Sed bibendum iaculis sagittis. Sed sed efficitur nunc. Nulla facilisi. Fusce nec sapien magna.

	Praesent a sollicitudin nisi, ac accumsan dolor. Aliquam facilisis tristique sem sit amet pharetra. Sed consequat elementum eros, quis feugiat mi. Vestibulum vestibulum malesuada nunc, ac facilisis mi. Cras fringilla, purus id facilisis fermentum, odio dolor suscipit mi, non vehicula arcu nisi at velit. Suspendisse et posuere est. Sed id nulla non neque ultrices rhoncus. Quisque rhoncus sem ac varius vulputate. Donec ut orci felis. Sed vel neque vel quam aliquet suscipit. Phasellus a ipsum eget velit cursus facilisis. Nulla facilisi. Sed sodales mauris at elit lacinia, ut venenatis nisl dictum. Integer ultrices neque non ipsum rhoncus, id blandit nisi euismod. Nunc dictum bibendum odio, ac iaculis quam tempus id.

	Vivamus in metus cursus, ultrices augue ut, iaculis tellus. Donec lacinia massa eget risus feugiat, in eleifend mauris aliquet. Aenean id bibendum metus. Nunc eu odio vitae odio luctus blandit ac a urna. Fusce tincidunt non nisl eu scelerisque. Suspendisse eget nunc pharetra, mattis justo nec, suscipit sapien. Sed in dictum nunc. Proin dignissim ullamcorper tincidunt. Nullam fringilla in quam ac sollicitudin. Vivamus in turpis nec arcu viverra egestas.

	Nam faucibus bibendum nisi, vel convallis quam dignissim non. Nulla facilisi. Ut facilisis, libero quis tincidunt convallis, nisi mi aliquet nulla, vel dictum elit ante eu orci. In vitae sem a mauris semper varius. Etiam accumsan, erat vel eleifend congue, mauris odio scelerisque quam, at vestibulum erat erat ac turpis. Fusce ac scelerisque purus. Aenean nec felis eu urna faucibus ullamcorper. Cras efficitur mi nec varius egestas. Pellentesque eleifend, ex quis fermentum dignissim, est erat posuere elit, nec fermentum purus sapien nec mauris. Vivamus semper lectus sit amet turpis venenatis eleifend. Aenean auctor, mauris eu auctor facilisis, mauris enim facilisis nisi, a congue quam elit eget velit. Nunc nec nisi ut quam auctor lacinia a quis elit. Integer luctus, dui vitae scelerisque eleifend, elit metus faucibus nisl, at ultricies lacus tortor in elit.

	Donec varius, orci quis pellentesque rutrum, nibh massa auctor urna, a fringilla quam lectus sit amet mauris. Aliquam gravida dui ut dolor iaculis vestibulum. Nam volutpat ultrices magna. Integer vel tellus nec nisi viverra gravida. Nunc ut mi ac sapien iaculis rutrum. Etiam dapibus euismod nibh a sollicitudin. In hac habitasse platea dictumst. Integer sed tortor a mi fringilla congue.

	Suspendisse potenti. Suspendisse potenti. Integer nec ex venenatis, ullamcorper lacus vel, tristique mi. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum eleifend est vel dapibus vestibulum. Aliquam a mauris a ex elementum sollicitudin. Aenean eu tristique elit. Fusce nec nunc eget libero efficitur venenatis. Donec vitae sapien non augue efficitur mattis. Sed tincidunt, ex eu scelerisque hendrerit, turpis lorem fringilla nibh, nec blandit justo turpis non metus. Vivamus venenatis urna nec velit tempus, in tincidunt nibh convallis. Cras accumsan velit et justo facilisis facilisis. Ut sit amet odio quis quam hendrerit suscipit. Curabitur ut augue sed mauris venenatis rhoncus at vel nulla. In ultrices id lorem nec eleifend. Sed volutpat elit nec felis auctor pharetra.
	'),
	(1, 0, 'Second Post', '2022-08-13', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ullamcorper auctor purus a laoreet. Fusce venenatis suscipit quam, in dictum justo congue non. Nullam at tincidunt lorem, sit amet consequat neque. Nulla facilisi. Ut tristique, enim id mollis viverra, erat massa vehicula felis, sit amet varius purus elit vel massa. Integer bibendum quam in sapien dictum, eu scelerisque ex faucibus. Curabitur posuere, felis a facilisis tempus, purus nibh ullamcorper arcu, ac maximus ipsum est eu sem. Sed pharetra metus in lacus aliquam dignissim. Vivamus eu sem quis elit sollicitudin convallis. Sed at quam facilisis, volutpat mauris a, tincidunt enim.

	Duis tincidunt, sapien eu luctus elementum, urna quam ultricies libero, eu congue est tortor vel justo. Nunc consequat consectetur sapien, nec rhoncus ipsum interdum sit amet. Fusce iaculis mauris in ex dignissim tincidunt. In hac habitasse platea dictumst. Sed bibendum iaculis sagittis. Sed sed efficitur nunc. Nulla facilisi. Fusce nec sapien magna.

	Praesent a sollicitudin nisi, ac accumsan dolor. Aliquam facilisis tristique sem sit amet pharetra. Sed consequat elementum eros, quis feugiat mi. Vestibulum vestibulum malesuada nunc, ac facilisis mi. Cras fringilla, purus id facilisis fermentum, odio dolor suscipit mi, non vehicula arcu nisi at velit. Suspendisse et posuere est. Sed id nulla non neque ultrices rhoncus. Quisque rhoncus sem ac varius vulputate. Donec ut orci felis. Sed vel neque vel quam aliquet suscipit. Phasellus a ipsum eget velit cursus facilisis. Nulla facilisi. Sed sodales mauris at elit lacinia, ut venenatis nisl dictum. Integer ultrices neque non ipsum rhoncus, id blandit nisi euismod. Nunc dictum bibendum odio, ac iaculis quam tempus id.

	Vivamus in metus cursus, ultrices augue ut, iaculis tellus. Donec lacinia massa eget risus feugiat, in eleifend mauris aliquet. Aenean id bibendum metus. Nunc eu odio vitae odio luctus blandit ac a urna. Fusce tincidunt non nisl eu scelerisque. Suspendisse eget nunc pharetra, mattis justo nec, suscipit sapien. Sed in dictum nunc. Proin dignissim ullamcorper tincidunt. Nullam fringilla in quam ac sollicitudin. Vivamus in turpis nec arcu viverra egestas.

	Nam faucibus bibendum nisi, vel convallis quam dignissim non. Nulla facilisi. Ut facilisis, libero quis tincidunt convallis, nisi mi aliquet nulla, vel dictum elit ante eu orci. In vitae sem a mauris semper varius. Etiam accumsan, erat vel eleifend congue, mauris odio scelerisque quam, at vestibulum erat erat ac turpis. Fusce ac scelerisque purus. Aenean nec felis eu urna faucibus ullamcorper. Cras efficitur mi nec varius egestas. Pellentesque eleifend, ex quis fermentum dignissim, est erat posuere elit, nec fermentum purus sapien nec mauris. Vivamus semper lectus sit amet turpis venenatis eleifend. Aenean auctor, mauris eu auctor facilisis, mauris enim facilisis nisi, a congue quam elit eget velit. Nunc nec nisi ut quam auctor lacinia a quis elit. Integer luctus, dui vitae scelerisque eleifend, elit metus faucibus nisl, at ultricies lacus tortor in elit.

	Donec varius, orci quis pellentesque rutrum, nibh massa auctor urna, a fringilla quam lectus sit amet mauris. Aliquam gravida dui ut dolor iaculis vestibulum. Nam volutpat ultrices magna. Integer vel tellus nec nisi viverra gravida. Nunc ut mi ac sapien iaculis rutrum. Etiam dapibus euismod nibh a sollicitudin. In hac habitasse platea dictumst. Integer sed tortor a mi fringilla congue.

	Suspendisse potenti. Suspendisse potenti. Integer nec ex venenatis, ullamcorper lacus vel, tristique mi. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum eleifend est vel dapibus vestibulum. Aliquam a mauris a ex elementum sollicitudin. Aenean eu tristique elit. Fusce nec nunc eget libero efficitur venenatis. Donec vitae sapien non augue efficitur mattis. Sed tincidunt, ex eu scelerisque hendrerit, turpis lorem fringilla nibh, nec blandit justo turpis non metus. Vivamus venenatis urna nec velit tempus, in tincidunt nibh convallis. Cras accumsan velit et justo facilisis facilisis. Ut sit amet odio quis quam hendrerit suscipit. Curabitur ut augue sed mauris venenatis rhoncus at vel nulla. In ultrices id lorem nec eleifend. Sed volutpat elit nec felis auctor pharetra.
	'),
	(2, 0, 'Third Post', '2022-10-29', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ullamcorper auctor purus a laoreet. Fusce venenatis suscipit quam, in dictum justo congue non. Nullam at tincidunt lorem, sit amet consequat neque. Nulla facilisi. Ut tristique, enim id mollis viverra, erat massa vehicula felis, sit amet varius purus elit vel massa. Integer bibendum quam in sapien dictum, eu scelerisque ex faucibus. Curabitur posuere, felis a facilisis tempus, purus nibh ullamcorper arcu, ac maximus ipsum est eu sem. Sed pharetra metus in lacus aliquam dignissim. Vivamus eu sem quis elit sollicitudin convallis. Sed at quam facilisis, volutpat mauris a, tincidunt enim.

	Duis tincidunt, sapien eu luctus elementum, urna quam ultricies libero, eu congue est tortor vel justo. Nunc consequat consectetur sapien, nec rhoncus ipsum interdum sit amet. Fusce iaculis mauris in ex dignissim tincidunt. In hac habitasse platea dictumst. Sed bibendum iaculis sagittis. Sed sed efficitur nunc. Nulla facilisi. Fusce nec sapien magna.

	Praesent a sollicitudin nisi, ac accumsan dolor. Aliquam facilisis tristique sem sit amet pharetra. Sed consequat elementum eros, quis feugiat mi. Vestibulum vestibulum malesuada nunc, ac facilisis mi. Cras fringilla, purus id facilisis fermentum, odio dolor suscipit mi, non vehicula arcu nisi at velit. Suspendisse et posuere est. Sed id nulla non neque ultrices rhoncus. Quisque rhoncus sem ac varius vulputate. Donec ut orci felis. Sed vel neque vel quam aliquet suscipit. Phasellus a ipsum eget velit cursus facilisis. Nulla facilisi. Sed sodales mauris at elit lacinia, ut venenatis nisl dictum. Integer ultrices neque non ipsum rhoncus, id blandit nisi euismod. Nunc dictum bibendum odio, ac iaculis quam tempus id.

	Vivamus in metus cursus, ultrices augue ut, iaculis tellus. Donec lacinia massa eget risus feugiat, in eleifend mauris aliquet. Aenean id bibendum metus. Nunc eu odio vitae odio luctus blandit ac a urna. Fusce tincidunt non nisl eu scelerisque. Suspendisse eget nunc pharetra, mattis justo nec, suscipit sapien. Sed in dictum nunc. Proin dignissim ullamcorper tincidunt. Nullam fringilla in quam ac sollicitudin. Vivamus in turpis nec arcu viverra egestas.

	Nam faucibus bibendum nisi, vel convallis quam dignissim non. Nulla facilisi. Ut facilisis, libero quis tincidunt convallis, nisi mi aliquet nulla, vel dictum elit ante eu orci. In vitae sem a mauris semper varius. Etiam accumsan, erat vel eleifend congue, mauris odio scelerisque quam, at vestibulum erat erat ac turpis. Fusce ac scelerisque purus. Aenean nec felis eu urna faucibus ullamcorper. Cras efficitur mi nec varius egestas. Pellentesque eleifend, ex quis fermentum dignissim, est erat posuere elit, nec fermentum purus sapien nec mauris. Vivamus semper lectus sit amet turpis venenatis eleifend. Aenean auctor, mauris eu auctor facilisis, mauris enim facilisis nisi, a congue quam elit eget velit. Nunc nec nisi ut quam auctor lacinia a quis elit. Integer luctus, dui vitae scelerisque eleifend, elit metus faucibus nisl, at ultricies lacus tortor in elit.

	Donec varius, orci quis pellentesque rutrum, nibh massa auctor urna, a fringilla quam lectus sit amet mauris. Aliquam gravida dui ut dolor iaculis vestibulum. Nam volutpat ultrices magna. Integer vel tellus nec nisi viverra gravida. Nunc ut mi ac sapien iaculis rutrum. Etiam dapibus euismod nibh a sollicitudin. In hac habitasse platea dictumst. Integer sed tortor a mi fringilla congue.

	Suspendisse potenti. Suspendisse potenti. Integer nec ex venenatis, ullamcorper lacus vel, tristique mi. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum eleifend est vel dapibus vestibulum. Aliquam a mauris a ex elementum sollicitudin. Aenean eu tristique elit. Fusce nec nunc eget libero efficitur venenatis. Donec vitae sapien non augue efficitur mattis. Sed tincidunt, ex eu scelerisque hendrerit, turpis lorem fringilla nibh, nec blandit justo turpis non metus. Vivamus venenatis urna nec velit tempus, in tincidunt nibh convallis. Cras accumsan velit et justo facilisis facilisis. Ut sit amet odio quis quam hendrerit suscipit. Curabitur ut augue sed mauris venenatis rhoncus at vel nulla. In ultrices id lorem nec eleifend. Sed volutpat elit nec felis auctor pharetra.
	');

INSERT INTO recipes (recipe_id, cuisine, prep_time, cook_time, servings, author_id, ingredients, instructions)
VALUES
	(0, 'fiendish', 40, 20, 4, 0, 'one egg, one trampoline, a little brother, a hose', 'Put the egg on the trampoline without your brother noticing, tell him to jump on the trampoline, spray him with the hose to make him slip and fall on the egg, then spray him again to wash the egg off of him.'),
	(1, 'dwarvish', 120, 13, 15, 0, 'thirteen dwarves, one hobbit, one wizard, two dozen barrels', 'Hide the dwarves in the barrels, have the hobbit ride on top and then BAMB! You have excaped the elves.  The wizard will take care of himself.'),
	(2, 'olympian', 65, 70, 3.5, 0, 'one apple, three selfish goddesses', 'throw the apple in the midst of the goddesses and voila, you have a trojan war.');

INSERT INTO ratings (recipe_id, user_id, rating)
VALUES
	(0, 1, 5), (0, 3, 3),(0, 2, 4),(1, 1, 4),(1, 2, 4),(1, 3, 5),(1, 4, 1),(2, 1, 5);

INSERT INTO post_recipes (recipe_id, post_id)
VALUES 	(0, 0), (1, 1), (2, 2), (1, 2);

INSERT INTO comments (comment_id, post_id, user_id, comment_text, publish_date, edited)
VALUES
	(0, 0, 0, 'Thank you for coming to my website!', '2022-07-20', 0),
	(1, 0, 1, 'Great Article!', '2022-08-20', 0),
	(2, 1, 1, 'I love this article aswell!', '2022-08-20', 1),
	(3, 1, 2, 'I agree! This is great!', '2022-09-01', 0),
	(4, 1, 1, 'Yup!', '2022-09-01', 1),
	(5, 1, 3, 'This is a mean comment that will be censored later.', '2022-10-15', 1),
	(6, 2, 4, 'This is a comment from a banned user that will be censored later.', '2022-11-09', 0);
	
INSERT INTO replies (original_id, reply_id)
VALUES (2, 3), (3, 4), (2,5);

INSERT INTO tags (tag_id, tag_name)
VALUES (0, 'lets go!'), (1, 'blog post'), (2, 'tasty'), (3, 'silly'), (4, 'fantasy'), (5, 'second entry');

INSERT INTO post_tags (post_id, tag_id)
VALUES (0, 0), (0, 1), (1, 5), (1, 1), (2, 1);

INSERT INTO recipe_tags (recipe_id, tag_id)
VALUES (0, 3), (0, 2), (1, 2), (1, 4), (1, 5), (2, 2), (2, 4);