| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Median       | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|-------------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3Native       | 128B         |     1.586 μs | 0.0056 μs | 0.0049 μs |     1.585 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 128B         |     2.326 μs | 0.0161 μs | 0.0143 μs |     2.325 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128B         |    10.203 μs | 0.0227 μs | 0.0190 μs |    10.199 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128B         |    19.635 μs | 0.0212 μs | 0.0177 μs |    19.634 μs |      56 B |
|                                             |              |              |           |           |              |           |
| AbsorbSqueeze · BLAKE3 · Blake3Native       | 1KB          |     2.153 μs | 0.0069 μs | 0.0058 μs |     2.153 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 1KB          |     3.222 μs | 0.0584 μs | 0.1038 μs |     3.173 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 1KB          |    14.396 μs | 0.0172 μs | 0.0152 μs |    14.393 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 1KB          |    28.870 μs | 0.0192 μs | 0.0170 μs |    28.870 μs |      56 B |
|                                             |              |              |           |           |              |           |
| AbsorbSqueeze · BLAKE3 · Blake3Native       | 8KB          |     6.683 μs | 0.0195 μs | 0.0173 μs |     6.684 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 8KB          |     9.843 μs | 0.0379 μs | 0.0355 μs |     9.836 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 8KB          |    47.527 μs | 0.0893 μs | 0.0791 μs |    47.506 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 8KB          |   103.897 μs | 0.1452 μs | 0.1358 μs |   103.841 μs |      56 B |
|                                             |              |              |           |           |              |           |
| AbsorbSqueeze · BLAKE3 · Blake3Native       | 128KB        |    84.178 μs | 0.1340 μs | 0.1046 μs |    84.162 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 128KB        |   124.927 μs | 0.6646 μs | 0.6216 μs |   125.221 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128KB        |   615.802 μs | 1.6926 μs | 1.5004 μs |   615.364 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128KB        | 1,401.698 μs | 1.8661 μs | 1.7456 μs | 1,401.425 μs |      56 B |