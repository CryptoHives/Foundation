| Description                                        | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128B         |     1.164 μs | 0.0043 μs | 0.0040 μs |  12,944 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128B         |     1.405 μs | 0.0017 μs | 0.0014 μs |   7,596 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 137B         |     1.224 μs | 0.0029 μs | 0.0027 μs |  12,949 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 137B         |     1.478 μs | 0.0008 μs | 0.0007 μs |  13,931 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1KB          |     7.661 μs | 0.0045 μs | 0.0037 μs |  13,134 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1KB          |     9.196 μs | 0.0069 μs | 0.0061 μs |  13,931 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 1025B        |     7.665 μs | 0.0055 μs | 0.0046 μs |  13,159 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 1025B        |     9.192 μs | 0.0069 μs | 0.0065 μs |   7,596 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 8KB          |    59.219 μs | 0.0359 μs | 0.0335 μs |  12,960 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 8KB          |    71.038 μs | 0.0331 μs | 0.0310 μs |  14,105 B |         - |
|                                                    |              |              |           |           |           |           |
| TryComputeHash · Ascon-XOF128 · CryptoHives-Scalar | 128KB        |   946.871 μs | 0.2512 μs | 0.2350 μs |  12,960 B |         - |
| TryComputeHash · Ascon-XOF128 · BouncyCastle       | 128KB        | 1,134.149 μs | 0.5742 μs | 0.5371 μs |  13,931 B |         - |