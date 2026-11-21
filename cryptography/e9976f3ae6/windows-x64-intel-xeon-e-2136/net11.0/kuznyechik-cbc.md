| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |     2.657 μs |  0.0123 μs |  0.0109 μs |  10,546 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128B         |    13.144 μs |  0.0158 μs |  0.0140 μs |  31,188 B |    1024 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |     2.408 μs |  0.0248 μs |  0.0232 μs |   4,021 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128B         |    13.433 μs |  0.0067 μs |  0.0056 μs |  28,492 B |     896 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |    18.879 μs |  0.0461 μs |  0.0409 μs |  10,356 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    70.006 μs |  0.0803 μs |  0.0670 μs |  31,226 B |    3712 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |    16.542 μs |  0.0602 μs |  0.0534 μs |  10,356 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    71.229 μs |  0.0181 μs |  0.0141 μs |  28,468 B |    2688 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |   149.489 μs |  0.4635 μs |  0.4109 μs |  10,356 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   520.305 μs |  0.6664 μs |  0.6233 μs |  22,241 B |   25216 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |   129.438 μs |  0.7281 μs |  0.6080 μs |   4,021 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   533.499 μs |  0.3616 μs |  0.3206 μs |  19,443 B |   17024 B |
|                                               |              |              |            |            |           |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        | 2,320.768 μs |  4.5144 μs |  4.0019 μs |   4,021 B |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 8,422.727 μs |  6.7562 μs |  6.3198 μs |  22,283 B |  393998 B |
|                                               |              |              |            |            |           |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        | 2,119.487 μs | 19.1350 μs | 16.9627 μs |   4,021 B |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 8,584.724 μs |  2.0710 μs |  1.9372 μs |  19,454 B |  262885 B |