| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-512 · Managed      | 128B         |     1.830 μs | 0.0055 μs | 0.0051 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 128B         |     2.960 μs | 0.0012 μs | 0.0011 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 128B         |     3.722 μs | 0.0017 μs | 0.0016 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-512 · Managed      | 137B         |     1.831 μs | 0.0049 μs | 0.0045 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 137B         |     2.970 μs | 0.0017 μs | 0.0015 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 137B         |     3.862 μs | 0.0036 μs | 0.0033 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-512 · Managed      | 1KB          |     6.946 μs | 0.0174 μs | 0.0163 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 1KB          |    11.731 μs | 0.0098 μs | 0.0092 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 1KB          |    14.271 μs | 0.0060 μs | 0.0056 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-512 · Managed      | 1025B        |     6.941 μs | 0.0171 μs | 0.0160 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 1025B        |    11.258 μs | 0.0089 μs | 0.0083 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 1025B        |    14.601 μs | 0.0113 μs | 0.0105 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-512 · Managed      | 8KB          |    47.912 μs | 0.1163 μs | 0.1088 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 8KB          |    77.533 μs | 0.0549 μs | 0.0513 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 8KB          |    97.118 μs | 0.1296 μs | 0.1212 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-512 · Managed      | 128KB        |   810.280 μs | 2.5851 μs | 2.4181 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 128KB        | 1,223.089 μs | 1.1195 μs | 1.0472 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 128KB        | 1,473.845 μs | 1.6190 μs | 1.4352 μs |         - |