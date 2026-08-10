| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3Native       | 128B         |     1.565 μs | 0.0020 μs | 0.0017 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 128B         |     2.321 μs | 0.0128 μs | 0.0120 μs |      24 B |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128B         |     9.962 μs | 0.0273 μs | 0.0242 μs |      24 B |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128B         |    19.492 μs | 0.0631 μs | 0.0590 μs |      56 B |
|                                             |              |              |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3Native       | 1KB          |     2.140 μs | 0.0261 μs | 0.0244 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 1KB          |     3.195 μs | 0.0078 μs | 0.0073 μs |      24 B |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 1KB          |    14.071 μs | 0.1196 μs | 0.1060 μs |      24 B |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 1KB          |    28.866 μs | 0.2060 μs | 0.1826 μs |      56 B |
|                                             |              |              |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3Native       | 8KB          |     6.598 μs | 0.0166 μs | 0.0156 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 8KB          |     9.803 μs | 0.0639 μs | 0.0534 μs |      24 B |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 8KB          |    47.740 μs | 0.5916 μs | 0.5534 μs |      24 B |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 8KB          |    98.091 μs | 0.3920 μs | 0.3667 μs |      56 B |
|                                             |              |              |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3Native       | 128KB        |    83.161 μs | 0.2063 μs | 0.1829 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 128KB        |   124.423 μs | 0.7720 μs | 0.7221 μs |      24 B |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128KB        |   602.926 μs | 3.0293 μs | 2.6854 μs |      24 B |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128KB        | 1,368.268 μs | 6.3637 μs | 5.9526 μs |      56 B |