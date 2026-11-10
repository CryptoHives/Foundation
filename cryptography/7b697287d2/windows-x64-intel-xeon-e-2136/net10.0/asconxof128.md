| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128B         |     1.160 μs | 0.0023 μs | 0.0021 μs |   4,016 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128B         |     1.414 μs | 0.0013 μs | 0.0010 μs |   4,942 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 137B         |     1.225 μs | 0.0046 μs | 0.0039 μs |   4,032 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 137B         |     1.484 μs | 0.0015 μs | 0.0012 μs |   4,942 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |     7.674 μs | 0.0059 μs | 0.0049 μs |   4,016 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1KB          |     9.248 μs | 0.0072 μs | 0.0067 μs |   4,942 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1025B        |     7.672 μs | 0.0043 μs | 0.0036 μs |   4,032 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1025B        |     9.246 μs | 0.0079 μs | 0.0070 μs |   4,929 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |    59.327 μs | 0.0381 μs | 0.0338 μs |   4,028 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 8KB          |    71.509 μs | 0.0753 μs | 0.0629 μs |   4,924 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128KB        |   949.301 μs | 0.6553 μs | 0.5472 μs |   3,975 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128KB        | 1,145.155 μs | 1.1796 μs | 1.0457 μs |   4,942 B |         - |