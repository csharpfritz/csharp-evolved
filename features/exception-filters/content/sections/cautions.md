Keep filter expressions predictable. If a filter throws while being evaluated, the runtime treats the filter as failed and continues looking for another handler.

That means filters are best for checks and lightweight logging, not for work that mutates state, allocates heavily, or depends on fragile helper code.
