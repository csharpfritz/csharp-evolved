You can only return references to storage that will still be alive after the method exits, such as an array element or a field on an existing object. You cannot return a ref to a local variable that is about to disappear.

Because a ref return exposes mutation directly, reserve it for cases where that coupling is intentional and beneficial. Many APIs are still clearer with ordinary return values.
