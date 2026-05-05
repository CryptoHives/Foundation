| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3Native       | 128B         |     1.589 μs | 0.0025 μs | 0.0020 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 128B         |     2.319 μs | 0.0134 μs | 0.0112 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128B         |    10.061 μs | 0.0372 μs | 0.0330 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128B         |    19.848 μs | 0.0409 μs | 0.0363 μs |      56 B |
|                                             |              |              |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3Native       | 1KB          |     2.153 μs | 0.0076 μs | 0.0064 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 1KB          |     3.173 μs | 0.0103 μs | 0.0086 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 1KB          |    14.158 μs | 0.0395 μs | 0.0369 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 1KB          |    28.901 μs | 0.0898 μs | 0.0796 μs |      56 B |
|                                             |              |              |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3Native       | 8KB          |     6.659 μs | 0.0145 μs | 0.0121 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 8KB          |     9.696 μs | 0.0301 μs | 0.0251 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 8KB          |    46.804 μs | 0.1287 μs | 0.1141 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 8KB          |   103.228 μs | 0.1771 μs | 0.1570 μs |      56 B |
|                                             |              |              |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3Native       | 128KB        |    84.006 μs | 0.1822 μs | 0.1615 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 128KB        |   123.646 μs | 0.3508 μs | 0.3281 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128KB        |   606.850 μs | 2.6969 μs | 2.3908 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128KB        | 1,369.993 μs | 3.2120 μs | 3.0045 μs |      56 B |