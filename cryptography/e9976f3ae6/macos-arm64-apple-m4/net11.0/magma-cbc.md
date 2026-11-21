| Description                              | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 128B         |     1.358 μs | 0.0052 μs | 0.0040 μs |         - |
| Decrypt · Magma-CBC (OpenGost)           | 128B         |     1.498 μs | 0.0036 μs | 0.0034 μs |     848 B |
|                                          |              |              |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 128B         |     1.637 μs | 0.0051 μs | 0.0042 μs |         - |
| Encrypt · Magma-CBC (OpenGost)           | 128B         |     1.788 μs | 0.0049 μs | 0.0044 μs |     720 B |
|                                          |              |              |           |           |           |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 1KB          |    10.217 μs | 0.0653 μs | 0.0579 μs |         - |
| Decrypt · Magma-CBC (OpenGost)           | 1KB          |    10.320 μs | 0.0487 μs | 0.0455 μs |    3536 B |
|                                          |              |              |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 1KB          |    12.480 μs | 0.0385 μs | 0.0360 μs |         - |
| Encrypt · Magma-CBC (OpenGost)           | 1KB          |    12.714 μs | 0.0356 μs | 0.0333 μs |    2512 B |
|                                          |              |              |           |           |           |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 8KB          |    81.009 μs | 0.4245 μs | 0.3971 μs |         - |
| Decrypt · Magma-CBC (OpenGost)           | 8KB          |    81.047 μs | 0.3656 μs | 0.3420 μs |   25040 B |
|                                          |              |              |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 8KB          |    98.941 μs | 0.2362 μs | 0.2094 μs |         - |
| Encrypt · Magma-CBC (OpenGost)           | 8KB          |   100.920 μs | 0.3647 μs | 0.3411 μs |   16848 B |
|                                          |              |              |           |           |           |
| Decrypt · Magma-CBC (CryptoHives-Scalar) | 128KB        | 1,297.932 μs | 8.8019 μs | 8.2333 μs |         - |
| Decrypt · Magma-CBC (OpenGost)           | 128KB        | 1,302.967 μs | 5.7498 μs | 5.3784 μs |  393757 B |
|                                          |              |              |           |           |           |
| Encrypt · Magma-CBC (CryptoHives-Scalar) | 128KB        | 1,582.967 μs | 5.5113 μs | 5.1553 μs |         - |
| Encrypt · Magma-CBC (OpenGost)           | 128KB        | 1,609.565 μs | 4.7632 μs | 4.4555 μs |  262659 B |