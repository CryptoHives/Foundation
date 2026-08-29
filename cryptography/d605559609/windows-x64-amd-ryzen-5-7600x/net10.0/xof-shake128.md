| Description                                   | TestDataSize | Mean       | Error     | StdDev    | Code Size | Allocated |
|---------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128B         |   2.716 μs | 0.0124 μs | 0.0116 μs |        NA |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128B         |   3.383 μs | 0.0322 μs | 0.0251 μs |   3,013 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128B         |   4.114 μs | 0.0156 μs | 0.0146 μs |   6,967 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 1KB          |   3.918 μs | 0.0247 μs | 0.0206 μs |        NA |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 1KB          |   4.849 μs | 0.0277 μs | 0.0246 μs |   3,013 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 1KB          |   5.943 μs | 0.0164 μs | 0.0137 μs |   6,994 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 8KB          |  12.300 μs | 0.0209 μs | 0.0185 μs |        NA |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 8KB          |  15.131 μs | 0.0345 μs | 0.0269 μs |   3,013 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 8KB          |  18.846 μs | 0.0279 μs | 0.0218 μs |   7,002 B |         - |
|                                               |              |            |           |           |           |           |
| AbsorbSqueeze · SHAKE128 · CryptoHives-Scalar | 128KB        | 158.076 μs | 0.4658 μs | 0.3889 μs |        NA |         - |
| AbsorbSqueeze · SHAKE128 · OS Native          | 128KB        | 194.769 μs | 0.5832 μs | 0.5455 μs |   3,013 B |         - |
| AbsorbSqueeze · SHAKE128 · BouncyCastle       | 128KB        | 243.241 μs | 0.6713 μs | 0.5951 μs |   6,994 B |         - |