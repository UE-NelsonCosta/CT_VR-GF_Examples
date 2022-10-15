Singletons

- Example of singletons pattern being used to create manager objects, or to simplify certain calls into general functions
- Singletons should be used when a larger overarching object like a manager, needs to manage lifetime of objects or control certain interactions
- Input would be another good example of this usage, but to bind said controls.
- These CANNOT have multiple instances, normally these "singletons" stay alive throughout an application lifetime