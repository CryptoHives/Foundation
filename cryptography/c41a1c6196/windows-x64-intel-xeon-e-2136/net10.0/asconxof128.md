| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128B         |     1.158 μs | 0.0016 μs | 0.0015 μs |   4,016 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128B         |     1.413 μs | 0.0017 μs | 0.0015 μs |   4,942 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 137B         |     1.222 μs | 0.0021 μs | 0.0020 μs |   4,032 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 137B         |     1.480 μs | 0.0015 μs | 0.0013 μs |   4,942 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |     7.671 μs | 0.0097 μs | 0.0086 μs |   4,016 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1KB          |     9.238 μs | 0.0086 μs | 0.0077 μs |   4,942 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1025B        |     7.673 μs | 0.0047 μs | 0.0042 μs |   4,032 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1025B        |     9.232 μs | 0.0122 μs | 0.0102 μs |   4,929 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |    59.230 μs | 0.0385 μs | 0.0360 μs |   4,039 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 8KB          |    71.460 μs | 0.0531 μs | 0.0471 μs |   4,942 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128KB        |   947.666 μs | 1.0746 μs | 0.9526 μs |   3,975 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128KB        | 1,141.787 μs | 1.2736 μs | 1.0635 μs |   4,942 B |         - |