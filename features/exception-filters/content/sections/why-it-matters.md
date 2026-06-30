Without filters, code often catches a broad exception, inspects it inside the handler, and then rethrows if the details do not match. Filters move that decision into the catch declaration itself, which keeps the recovery path smaller and makes the intent obvious.

They also preserve useful debugging behavior because the runtime has not fully unwound into the handler unless the filter passes.
