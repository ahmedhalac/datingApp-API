﻿using API.Entities;

namespace API.DTOs;

public class PhotoDto
{
    public string Id { get; set; }

    public string Url { get; set; }

    public bool isMain { get; set; }
}