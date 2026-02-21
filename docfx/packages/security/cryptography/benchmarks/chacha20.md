| Description                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|---------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · ChaCha20 (AVX2)         | 128B         |      70.59 ns |     1.097 ns |     1.027 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 128B         |     128.03 ns |     0.629 ns |     0.557 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 128B         |     285.18 ns |     3.782 ns |     3.158 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 128B         |     315.97 ns |     4.141 ns |     3.874 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 128B         |     461.93 ns |     1.257 ns |     0.981 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 128B         |      70.08 ns |     0.436 ns |     0.364 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 128B         |     128.19 ns |     1.332 ns |     1.181 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 128B         |     279.52 ns |     1.314 ns |     1.229 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 128B         |     307.95 ns |     1.886 ns |     1.764 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 128B         |     454.81 ns |     1.861 ns |     1.649 ns |         - |
|                                   |              |               |              |              |           |
| Decrypt · ChaCha20 (AVX2)         | 1KB          |     539.67 ns |    10.651 ns |    14.218 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 1KB          |   1,003.51 ns |     5.488 ns |     4.865 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 1KB          |   1,531.79 ns |     6.165 ns |     5.767 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 1KB          |   1,841.67 ns |    26.206 ns |    24.513 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 1KB          |   3,618.65 ns |    34.114 ns |    30.241 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 1KB          |     524.75 ns |     5.184 ns |     4.849 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 1KB          |   1,007.16 ns |     5.790 ns |     5.132 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 1KB          |   1,540.01 ns |     3.559 ns |     2.779 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 1KB          |   1,777.83 ns |    11.399 ns |    10.663 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 1KB          |   3,542.92 ns |    23.990 ns |    22.440 ns |         - |
|                                   |              |               |              |              |           |
| Decrypt · ChaCha20 (AVX2)         | 8KB          |   4,149.64 ns |    29.680 ns |    26.310 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 8KB          |   8,025.39 ns |    43.290 ns |    40.494 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 8KB          |  11,466.67 ns |    60.038 ns |    56.160 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 8KB          |  13,984.88 ns |   160.782 ns |   150.395 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 8KB          |  28,628.86 ns |   110.734 ns |    98.162 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 8KB          |   4,157.32 ns |    39.397 ns |    36.852 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 8KB          |   8,038.80 ns |    98.353 ns |    87.187 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 8KB          |  11,339.38 ns |    60.555 ns |    56.643 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 8KB          |  13,476.36 ns |    80.771 ns |    71.602 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 8KB          |  28,217.45 ns |   154.385 ns |   144.412 ns |         - |
|                                   |              |               |              |              |           |
| Decrypt · ChaCha20 (AVX2)         | 128KB        |  66,936.71 ns |   871.827 ns |   895.302 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 128KB        | 131,021.77 ns | 2,555.829 ns | 3,042.532 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 128KB        | 182,895.61 ns | 2,991.740 ns | 2,798.475 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 128KB        | 223,027.40 ns | 4,250.841 ns | 4,174.894 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 128KB        | 474,239.09 ns | 9,472.052 ns | 9,302.822 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 128KB        |  66,453.06 ns |   472.718 ns |   394.741 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 128KB        | 129,013.25 ns | 2,395.516 ns | 2,123.563 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 128KB        | 180,612.54 ns |   874.150 ns |   774.911 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 128KB        | 218,037.73 ns | 1,178.119 ns | 1,102.013 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 128KB        | 457,432.60 ns | 1,526.092 ns | 1,352.841 ns |         - |