| Description                            | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|--------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| ComputeHash · SM3 · SM3 (Managed)      | 128B         |   1.080 μs | 0.0027 μs | 0.0023 μs |     112 B |
| ComputeHash · SM3 · SM3 (BouncyCastle) | 128B         |   1.236 μs | 0.0050 μs | 0.0045 μs |     112 B |
|                                        |              |            |           |           |           |
| ComputeHash · SM3 · SM3 (Managed)      | 137B         |   1.085 μs | 0.0026 μs | 0.0022 μs |     112 B |
| ComputeHash · SM3 · SM3 (BouncyCastle) | 137B         |   1.238 μs | 0.0068 μs | 0.0057 μs |     112 B |
|                                        |              |            |           |           |           |
| ComputeHash · SM3 · SM3 (Managed)      | 1KB          |   5.686 μs | 0.0276 μs | 0.0245 μs |     112 B |
| ComputeHash · SM3 · SM3 (BouncyCastle) | 1KB          |   6.461 μs | 0.0256 μs | 0.0227 μs |     112 B |
|                                        |              |            |           |           |           |
| ComputeHash · SM3 · SM3 (Managed)      | 1025B        |   5.668 μs | 0.0163 μs | 0.0128 μs |     112 B |
| ComputeHash · SM3 · SM3 (BouncyCastle) | 1025B        |   6.452 μs | 0.0170 μs | 0.0151 μs |     112 B |
|                                        |              |            |           |           |           |
| ComputeHash · SM3 · SM3 (Managed)      | 8KB          |  42.452 μs | 0.2005 μs | 0.1876 μs |     112 B |
| ComputeHash · SM3 · SM3 (BouncyCastle) | 8KB          |  49.068 μs | 0.1789 μs | 0.1586 μs |     112 B |
|                                        |              |            |           |           |           |
| ComputeHash · SM3 · SM3 (Managed)      | 128KB        | 664.013 μs | 2.2170 μs | 2.0738 μs |     112 B |
| ComputeHash · SM3 · SM3 (BouncyCastle) | 128KB        | 767.810 μs | 2.7521 μs | 2.5743 μs |     112 B |