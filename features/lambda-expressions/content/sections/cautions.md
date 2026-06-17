Use a named method when the logic grows beyond a few lines or needs a clear test target. Lambdas are best for short, focused behavior.

Also remember that lambdas can capture local variables from their surrounding scope. That is powerful, but it can make lifetime and mutation behavior less obvious if you overuse it.
