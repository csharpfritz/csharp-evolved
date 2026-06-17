Extension methods are easy to overuse. If a helper is only relevant in one place, a normal static method may be clearer.

They also do not override instance methods. If the target type already defines a matching instance member, the instance member wins.
