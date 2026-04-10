| Description                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|---------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · ChaCha20 (AVX2)         | 128B         |      75.68 ns |     0.444 ns |     0.394 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 128B         |     134.86 ns |     0.826 ns |     0.773 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 128B         |     276.82 ns |     1.060 ns |     0.992 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 128B         |     312.18 ns |     2.642 ns |     2.342 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 128B         |     456.49 ns |     1.908 ns |     1.691 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 128B         |      76.56 ns |     1.504 ns |     1.544 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 128B         |     135.35 ns |     0.443 ns |     0.393 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 128B         |     277.28 ns |     1.209 ns |     1.131 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 128B         |     312.66 ns |     2.545 ns |     2.381 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 128B         |     457.12 ns |     2.619 ns |     2.450 ns |         - |
|                                   |              |               |              |              |           |
| Decrypt · ChaCha20 (AVX2)         | 1KB          |     525.91 ns |     4.482 ns |     3.973 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 1KB          |   1,008.29 ns |     4.655 ns |     4.354 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 1KB          |   1,502.46 ns |     4.479 ns |     3.740 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 1KB          |   1,785.94 ns |     8.947 ns |     7.931 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 1KB          |   3,556.56 ns |    11.988 ns |    11.213 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 1KB          |     528.12 ns |     3.474 ns |     3.249 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 1KB          |   1,006.59 ns |     2.732 ns |     2.133 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 1KB          |   1,638.70 ns |     8.568 ns |     7.595 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 1KB          |   1,781.76 ns |     9.766 ns |     9.135 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 1KB          |   3,563.02 ns |    16.407 ns |    15.347 ns |         - |
|                                   |              |               |              |              |           |
| Decrypt · ChaCha20 (AVX2)         | 8KB          |   4,125.93 ns |    16.081 ns |    13.428 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 8KB          |   7,990.33 ns |    56.958 ns |    53.279 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 8KB          |  11,336.11 ns |    40.840 ns |    38.201 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 8KB          |  13,482.71 ns |    69.659 ns |    65.159 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 8KB          |  28,374.97 ns |   136.354 ns |   127.546 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 8KB          |   4,140.73 ns |    16.123 ns |    14.293 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 8KB          |   8,004.68 ns |    57.465 ns |    47.986 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 8KB          |  11,258.99 ns |    41.624 ns |    36.899 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 8KB          |  13,487.47 ns |    53.809 ns |    50.333 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 8KB          |  28,347.96 ns |   160.409 ns |   150.046 ns |         - |
|                                   |              |               |              |              |           |
| Decrypt · ChaCha20 (AVX2)         | 128KB        |  65,888.43 ns |   364.875 ns |   323.452 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 128KB        | 127,688.35 ns |   410.276 ns |   342.599 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 128KB        | 178,998.61 ns |   848.124 ns |   751.839 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 128KB        | 214,721.25 ns | 1,137.771 ns | 1,064.272 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 128KB        | 453,662.60 ns | 1,523.141 ns | 1,350.225 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 128KB        |  66,417.48 ns | 1,281.206 ns | 1,135.756 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 128KB        | 127,773.27 ns |   498.315 ns |   441.744 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 128KB        | 180,241.94 ns | 1,045.354 ns |   977.825 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 128KB        | 214,483.68 ns |   794.543 ns |   704.342 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 128KB        | 452,769.71 ns | 1,477.982 ns | 1,310.192 ns |         - |