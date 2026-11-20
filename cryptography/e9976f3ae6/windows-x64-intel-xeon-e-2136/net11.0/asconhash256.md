| Description                                         | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128B         |     1.159 μs | 0.0015 μs | 0.0014 μs |  13,132 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128B         |     1.410 μs | 0.0006 μs | 0.0006 μs |  14,241 B |         - |
|                                                     |              |              |           |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 137B         |     1.221 μs | 0.0011 μs | 0.0010 μs |   6,612 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 137B         |     1.483 μs | 0.0010 μs | 0.0008 μs |  14,051 B |         - |
|                                                     |              |              |           |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1KB          |     7.660 μs | 0.0029 μs | 0.0026 μs |   6,607 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1KB          |     9.243 μs | 0.0019 μs | 0.0017 μs |  14,250 B |         - |
|                                                     |              |              |           |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 1025B        |     7.667 μs | 0.0057 μs | 0.0054 μs |  12,947 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 1025B        |     9.243 μs | 0.0081 μs | 0.0076 μs |  14,060 B |         - |
|                                                     |              |              |           |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 8KB          |    59.177 μs | 0.0130 μs | 0.0109 μs |   6,623 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 8KB          |    71.491 μs | 0.0666 μs | 0.0623 μs |  14,275 B |         - |
|                                                     |              |              |           |           |           |           |
| TryComputeHash · Ascon-Hash256 · CryptoHives-Scalar | 128KB        |   947.040 μs | 0.1498 μs | 0.1328 μs |   6,623 B |         - |
| TryComputeHash · Ascon-Hash256 · BouncyCastle       | 128KB        | 1,145.075 μs | 0.3759 μs | 0.3333 μs |  14,286 B |         - |