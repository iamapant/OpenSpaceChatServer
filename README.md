# OpenSpaceChatServer
A location-aware public chat where users can express themselves and explore what others nearby are sharing, all without personal interaction or social pressure.
This app main aim is to provide a layer of comfort for socially awkward individual, often people with a reliance on social medias by exposing other users' experiences around them; this app also cater to adventurous users who like to store and share their memories in the form of text and short form medias (pictures, clips, voice recordings,... ) messages while offering positive feedbacks in the form of reactions.

## How it works
- Users can post messages on the public channel, allowing other users to view and react to them
- These messages will fade after a certain period of time
- Messages with a lot of reactions will persist for longer, and after reaching a threshold of reactions (based on density of users, a factor of reaction per user, average amount of reactions per message atm) the message is `Enhanced`, allowing for more customization and `Archived`, persist for a long period of time (days-months-forever)
- Tapping on a public message will open up 2 selection menu: The first is for choosing reactions to the message itself, and the second is where they can choose between Dm-ing the poster, viewing their profile, vote to `Silence` them in the public channel, and blocking or reporting it
- When a vote to silence someone on the public channel is initiated, every users within the message's reach plus anyone who have reacted to it will receive a [pop up](https://drive.google.com/file/d/1IKJoPYBEMIsBcZNqCSDokjnBtsv4ouho/view?usp=drive_link) allowing them to cast their vote on whether to `Silence` this user for a while or not
- There's a Dm feature where users can talk privately to eachother or in group. Members in a Dm conversation can choose to publicize a 'recent' message, which will send that message to the public channel, with the publisher(or poster?) as the poster with their current location and timestamp.
- Each user have a profile page where they can set-up their avatar/banner/wallpaper, organize archived messages, and overall personalized it. The profile page will be public for everyone (except blocked users)
- Users can befriend eachother using invite code or through their profile.

## WIP:
- In progress:
  - Main server - regional server Communication via protobuf,
  - Message decoration (public/private message decoration, archived messages re-decoration/additional decoration, decoration store(?))
  - Migrating functions to regional server: Public messages, Messages Id assignment, Active users
  - Regional server's Redis implementation
    
- Planning:
  - Mobile app written in Flutter (compatible with iOS and Android)
  - Crowd Finder: Identify areas of high message traffic near the user 
  - Friendlist: Allows friends to view eachother messages anywhere, Dm - Group Dms, Allow friends to view eachother live `Public view` as if they are there ( -> and chatting to eachother in a hybrid public-dm chatbox)
  - Precise position tracking
  - [Journey mode](https://drive.google.com/file/d/1DglwePVirI6x_1VksgPXT0icnb0mQixI/view?usp=sharing): Aims at tourists/adventurers, this feature allows user to establish a timeline with path (on map overlay) of messages they published. How-tos: User click to start a new journey or select a few recent messages -> every subsequent public messages will be mark as a new node in the journey (can be opt out) -> Journey messages will be highlighted (to friend and poster) -> User end the journey (or server timeout'd). Journey and its messages are automatically archived. 
  - Offline mode: Persistent GPS signal, offline GPS fetching, fallback choose position prompt when GPS fetched, automatic posting when online, journey in offline mode (good for airplane rides, mountain hiking, ocean cruises,... )
  - Relay mode (on Android via Wifi Direct): In case of 
  - [Public view](https://drive.google.com/file/d/1pGkOfjMcJ4Ko2pEcGGKG4em_aQGaJMT7/view?usp=sharing): Instead of the tranditional chat box, `Public view` let the user see the message as they pop up around them. User can move the camera around a large area, zoom, tilt,... and even viewing messages in AR by holding up their phone and point to the direction of the messages). User can tap on a message(except for archive messages where users are no longer close by) to initiate a conversation with its poster. It also have a horizontal scrollbar where users can scroll back to recent messages. Archived messages are highlighted/decorated with even more options than normal messages, making them stand out more.
  - 3D Mapping: Allow viewing messages in 3D space, Map topography
 
* Pending names: Hum(Hăm)
