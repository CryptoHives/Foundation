| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · Streebog-512 · Managed      | 128B         |     1.783 μs | 0.0053 μs | 0.0050 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 128B         |     2.917 μs | 0.0076 μs | 0.0071 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 128B         |     3.681 μs | 0.0094 μs | 0.0088 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-512 · Managed      | 137B         |     1.783 μs | 0.0062 μs | 0.0055 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 137B         |     2.920 μs | 0.0065 μs | 0.0061 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 137B         |     3.771 μs | 0.0119 μs | 0.0111 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-512 · Managed      | 1KB          |     6.776 μs | 0.0235 μs | 0.0220 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 1KB          |    11.084 μs | 0.0169 μs | 0.0158 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 1KB          |    14.168 μs | 0.0303 μs | 0.0284 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-512 · Managed      | 1025B        |     6.767 μs | 0.0212 μs | 0.0199 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 1025B        |    11.091 μs | 0.0259 μs | 0.0230 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 1025B        |    14.232 μs | 0.0319 μs | 0.0299 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-512 · Managed      | 8KB          |    46.593 μs | 0.1759 μs | 0.1560 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 8KB          |    76.431 μs | 0.1951 μs | 0.1825 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 8KB          |    96.309 μs | 0.2186 μs | 0.2045 μs |         - |
|                                              |              |              |           |           |           |
| TryComputeHash · Streebog-512 · Managed      | 128KB        |   733.762 μs | 4.3234 μs | 4.0441 μs |         - |
| TryComputeHash · Streebog-512 · OpenGost     | 128KB        | 1,201.878 μs | 4.9023 μs | 4.5856 μs |     176 B |
| TryComputeHash · Streebog-512 · BouncyCastle | 128KB        | 1,522.239 μs | 4.5362 μs | 4.2432 μs |         - |